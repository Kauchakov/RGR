using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

class dataBaseConnection //Коннект с бд, которая является бинарным SQlite-файлом
{
    private const string fileName = "dt.bytes";
    private static string DBPath;
    private static SqliteConnection connection;
    private static SqliteCommand command;

    static dataBaseConnection()
    {
        DBPath = Application.streamingAssetsPath + "/" + fileName;
    }
    private static void OpenConnection()
    {
        connection = new SqliteConnection("Data Source=" + DBPath);
        command = new SqliteCommand(connection);
        connection.Open();
    }

    public static void CloseConnection()
    {
        connection.Close();
        command.Dispose();
    }

    public static DataTable GetTable(string query)
    {
        OpenConnection();

        SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection);

        DataSet DS = new DataSet();
        adapter.Fill(DS);
        adapter.Dispose();

        CloseConnection();

        return DS.Tables[0];
    }
}

