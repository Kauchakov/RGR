using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Dom;
using System.IO;
using System.Net;
using static System.Net.WebRequestMethods;

namespace testBD
{
    public partial class Form1 : Form
    {
        
        List<string> a = new List<string>();
        List<string> b = new List<string>();

        Class1 dataBase = new Class1();
        public Form1()
        {

            InitializeComponent();

            dataBase.OpenConnection();

            string data = "", dataDescription = "";



            for (int i = 192; i < 224; i++)
            {
                string urlAddress = "https://slovarozhegova.ru/letter.php?charkod=" + i;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    data += readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                }
            }

            var parser = new HtmlParser();
            var html = data;
            var doc = parser.ParseDocument(html);
            foreach (IElement element in doc.QuerySelectorAll("a"))
            {
                if (element.GetAttribute("class") == "chara" && element.GetAttribute("href")[0] == 'w')
                {
                    string urlDesc = "https://slovarozhegova.ru/" + element.GetAttribute("href");

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlDesc);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream receiveStream = response.GetResponseStream();
                        StreamReader readStream = null;
                        if (response.CharacterSet == null)
                            readStream = new StreamReader(receiveStream);
                        else
                            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                        dataDescription = readStream.ReadToEnd();
                        response.Close();
                        readStream.Close();
                    }
                    foreach (IElement element2 in parser.ParseDocument(dataDescription).QuerySelectorAll("div"))
                    {
                        if (element2.GetAttribute("class") == "textdiv")
                        {
                            dataDescription = element2.Text();
                            dataDescription = dataDescription.Remove(0, 27 + element.Text().Length);
                            b.Add(dataDescription);
                        }
                    }
                    a.Add(element.Text());
                }

            }
            for (int i = 0; i < a.Count; i++)
                listBox1.Items.Add(a[i]);
            dataBase.CloseConnection();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        List<string> f = new List<string>();
        private void textBox1_TextChangedAsync(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            string QueryString = $"select word from dataWords";
            SqlCommand command = new SqlCommand(QueryString, dataBase.getConnection());

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string word = reader.GetString(0);

                    f.Add(word);
                }
            }
            //textBox1.Text = f[0] + " " + f[1];
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private bool OnlyLetters(string word)
        {
            foreach (char el in word)
                if (!((int)el >= 1040 && (int)el <= 1071))
                    return false;
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = dataBase.getConnection();
            for (int i = 0; i < a.Count; i++)
            {
                string word = a[i];
                string desc = b[i];
                if (desc.Length > 7899)
                    desc.Remove(7900);
                if(!OnlyLetters(word))
                    continue;
                command.CommandText = @"INSERT INTO dataWords VALUES ('" + word + "', '" + desc +"')";
                try
                {
                    command.ExecuteNonQuery();
                }
                catch(System.Data.SqlClient.SqlException)
                {

                }
            }

                
            dataBase.CloseConnection();
            
        }
    }
}
