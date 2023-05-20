using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionWord : MonoBehaviour
{
    public string Word;
    public string Description;
    Transform DescriptionField;
    public void Awake()
    {
        DescriptionField = GameObject.FindGameObjectWithTag("Description").GetComponentInChildren<RectTransform>();
        try
        {
            gameObject.GetComponent<Button>().onClick.AddListener(Select); //Добавляем событие о описании слова
        }
        catch(NullReferenceException) { }
    }
    public void Select() //Выбор слова
    {
        for (int i = 0; i < DescriptionField.childCount; i++)
            DescriptionField.GetChild(i).gameObject.SetActive(true);
        try
        {
            Word = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
            DescriptionField.GetChild(0).GetChild(0).GetComponentInChildren<TextMesh>().text = Word.ToLower();

            Description = Properties.AllCircles[Word];
            DescriptionField.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = Description;
        }
        catch(KeyNotFoundException ex)
        {
            Debug.Log(ex.Message);
        }
    }

}
