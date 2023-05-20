using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Table : MonoBehaviour //Подключение к БД
{
    public static DataTable table;
    void Start()
    {
        table = dataBaseConnection.GetTable("select * from dataWords;");
    }
}
