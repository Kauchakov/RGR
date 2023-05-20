using UnityEngine;

public class Score : MonoBehaviour
{
    private void ScoreText()
    {
        transform.GetChild(0).GetComponent<TextMesh>().text = "Score: " + Properties.Score;
        transform.GetChild(1).GetComponent<TextMesh>().text = "Score: " + Properties.Score;
    }
    private void Update()
    {
        ScoreText();
    }
}
