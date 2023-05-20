using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour //—цены
{
    [SerializeField] public string scene;
    public static float onPause = 1;
    public void UpTime()
    {
        Time.timeScale = 1.0f;
        onPause = 0;
    }
    public void LoadScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
