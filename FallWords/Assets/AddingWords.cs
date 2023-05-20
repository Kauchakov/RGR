using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class AddingWords : MonoBehaviour
{
    [SerializeField] public Transform Parent; 
    [SerializeField] public GameObject Prefab; 
    public void Awake() //Добавление элемента слова в другой как "child"
    {
        foreach (var word in Properties.AllCircles)
        {
            GameObject FieldWithWord = Instantiate(Prefab, Prefab.transform.position, Quaternion.identity);
            FieldWithWord.GetComponentInChildren<TextMeshProUGUI>().text = word.Key;
            FieldWithWord.GetComponent<RectTransform>().SetParent(Parent, false);
        }
    }
}
