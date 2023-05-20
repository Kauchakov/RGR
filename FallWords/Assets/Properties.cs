using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Properties : MonoBehaviour
{
    [SerializeField] public GameObject Text;
    [SerializeField] public string Word;
    public static int Score = 0;
    public DateTime timeOfCreation;
    Random random = new Random();
    public static int HealthPoits = 3;
    //public static List<string> words = new List<string>() { "никита", "полина", "экспансия", "собака", "расстояние", "язык", "поводок", "призыв", "лунтик", "луна", "на", "привет", "ангар", "бутерброд", "продовольствие", "правительство"};
    public static Dictionary<string, string> AllCircles = new Dictionary<string, string>();
    void Awake()
    {
        int RandomWord = random.Next(0, 32667);

        string wordFromDB = Table.table.Rows[RandomWord][1].ToString();
        string Description = Table.table.Rows[RandomWord][2].ToString();
        AllCircles.Add(wordFromDB, Description);
        Debug.Log(Description);

        timeOfCreation = DateTime.Now;
        transform.position = new Vector3((float)random.Next(-80, 80) / 10, 5.5f, 100);
        Text.GetComponent<TextMesh>().text = wordFromDB.ToLower();//words.ElementAt(UnityEngine.Random.Range(0, words.Count));
        Word = wordFromDB.ToLower(); //Text.GetComponent<TextMesh>().text;
    }
}
