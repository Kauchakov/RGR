using System;
using System.Linq;
using UnityEngine;

public class Buffer : MonoBehaviour
{
    public static string buffer;
    public static DateTime now;
    bool delete = false, isOn = true;
    void Update()
    {
        if (Input.anyKeyDown && Time.timeScale > 0) //Заполнение слова цветом при вводе
        {
            char.TryParse(Input.inputString, out char result);
            if (buffer == "")
                now = DateTime.Now;
            buffer += result;
            foreach (var item in CreateCircles.circles)
            {
                if (item == null)
                    continue;
                if (item.GetComponent<Boom>().Check(item) && (now - item.GetComponent<Properties>().timeOfCreation).Seconds >= 0 )
                {
                    item.GetComponent<Boom>().Color(buffer.Length);
                    if (buffer.Length == item.GetComponent<Properties>().Word.Length)
                    {
                        Destroy(item);
                        delete = true;
                        Properties.Score++;
                    }
                }
            }
            if (delete)
            {
                buffer = "";
                delete = false;
            }
            CreateCircles.circles.RemoveAll(s => s == null);
            int countOfZero = 0;
            for (int i = 0; i < CreateCircles.circles.Count; i++)
            {
                if (CreateCircles.circles.ElementAt(i).GetComponent<Properties>().Text.GetComponent<TextMesh>().text.ElementAt(0).ToString() != "<")
                    countOfZero++;
            }
            if (countOfZero == CreateCircles.circles.Count)
                buffer = "";
        }
        //if (Input.GetKeyDown(KeyCode.Escape) && Properties.HealthPoits != 0)
        //{
        //    if (isOn)
        //    {
        //        Time.timeScale = 0;
        //        isOn = false;
        //    }
        //    else
        //    {
        //        Time.timeScale = 1;
        //        isOn = true;
        //    }
        //}
    }
}
