using System.Linq;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] public GameObject Text;
    private string WordB, Colour;
    private void Start()
    {
        Colour = "#DC143C";
        WordB = GetComponent<Properties>().Word;
    }
    public void Color(int count) //Цвет, меняющийся в переменной Colour
    {
        Text.GetComponent<TextMesh>().text = WordB;
        Text.GetComponent<TextMesh>().text = Text.GetComponent<TextMesh>().text.Insert(0, "<color=" + Colour + ">");
        Text.GetComponent<TextMesh>().text = Text.GetComponent<TextMesh>().text.Insert(count + (8 + Colour.Length), "</color>");
    }
    public bool Check(GameObject item) //Проверка есть ли такая следующая буква 
    {
        for (int i = 0; i < Buffer.buffer.Length; i++)
            if (!item.GetComponent<Properties>().Word.ElementAt(i).ToString().Equals(Buffer.buffer.ElementAt(i).ToString()))
            {
                item.GetComponent<Properties>().Text.GetComponent<TextMesh>().text = item.GetComponent<Properties>().Word;
                return false;
            }
        return true;
    }
}
