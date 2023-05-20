using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour //Выбор уровня
{
    public static float speedCircles = 0.1f, timeOfCreating = 4f;
    public void EasyLevel()
    {
        speedCircles = 0.1f; timeOfCreating = 4f;
        SceneManage.onPause = 1;
        Properties.HealthPoits = 3;
    }
    public void MediumLevel()
    {
        speedCircles = 0.25f; timeOfCreating = 3f;
        SceneManage.onPause = 1;
        Properties.HealthPoits = 3;
    }
    public void HardLevel()
    {
        speedCircles = 0.5f; timeOfCreating = 2f;
        SceneManage.onPause = 1;
        Properties.HealthPoits = 3;
    }
}
