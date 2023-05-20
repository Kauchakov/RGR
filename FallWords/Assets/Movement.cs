using System;
using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour //Движение шариков
{
    [SerializeField] private float Speed, SpeedK;
    [SerializeField] private int Angle, Side;
    [SerializeField] private Vector3 StartPosition, FinalPosition;

    void Start()
    {
        Side = 1;
        Speed = (float) 1 / GetComponent<Properties>().Word.Length;
        Angle = UnityEngine.Random.Range(-45, 45);
        StartPosition = transform.position;
        FinalPosition = new Vector3(StartPosition.x + (10 * (float)Math.Tan(Angle * (float)Math.PI / 180)), -4.5f, 0); // tg = x/10
        SpeedK = 500;
    }
    void Update()
    {
        if (transform.position.x > 8.5 || transform.position.x < -8.5)
            Side *= -1;
        //if (Speed + ((float)(DateTime.Now - CreateCircles.timeOfStart).Seconds) / 1000 < Speed + 0.5f)
        //{
        // Debug.Log(Speed + ((float)(DateTime.Now - CreateCircles.timeOfStart).Seconds) / SpeedK);
        //    if (Angle > 0)
        //        transform.Translate(Time.deltaTime * ((Speed + ((float)(DateTime.Now - CreateCircles.timeOfStart).Seconds) / SpeedK) * ((Math.Abs(FinalPosition.x - StartPosition.x) / 10) == 0 ? 1 : (Math.Abs(FinalPosition.x - StartPosition.x) / 10))) * Side,
        //                            -Time.deltaTime * (Speed + ((float)(DateTime.Now - CreateCircles.timeOfStart).Seconds) / SpeedK), 0);
        //    else
        //        transform.Translate(-Time.deltaTime * ((Speed + ((float)(DateTime.Now - CreateCircles.timeOfStart).Seconds) / SpeedK) * ((Math.Abs(FinalPosition.x - StartPosition.x) / 10) == 0 ? 1 : (Math.Abs(FinalPosition.x - StartPosition.x) / 10))) * Side,
        //                            -Time.deltaTime * (Speed + ((float)(DateTime.Now - CreateCircles.timeOfStart).Seconds) / SpeedK), 0);

        //}
        //else
        //{
        if (Speed + ((float)(DateTime.Now - CreateCircles.timeOfStart).Seconds) / 1000 < Speed + 0.5f)
        {
            if (Angle > 0)
                transform.Translate(Time.deltaTime * ((Speed + ((float)(DateTime.Now - CreateCircles.timeOfStart).Seconds) / SpeedK + (float)Levels.speedCircles) * ((Math.Abs(FinalPosition.x - StartPosition.x) / 10) == 0 ? 1 : (Math.Abs(FinalPosition.x - StartPosition.x) / 10))) * Side * SceneManage.onPause,
                                    -Time.deltaTime * (Speed + ((float)(DateTime.Now - CreateCircles.timeOfStart).Seconds) / SpeedK + (float)Levels.speedCircles) * SceneManage.onPause, 0);
            else
                transform.Translate(-Time.deltaTime * ((Speed + ((float)(DateTime.Now - CreateCircles.timeOfStart).Seconds) / SpeedK + (float)Levels.speedCircles) * ((Math.Abs(FinalPosition.x - StartPosition.x) / 10) == 0 ? 1 : (Math.Abs(FinalPosition.x - StartPosition.x) / 10))) * Side * SceneManage.onPause,
                                        -Time.deltaTime * (Speed + ((float)(DateTime.Now - CreateCircles.timeOfStart).Seconds) / SpeedK + (float)Levels.speedCircles) * SceneManage.onPause, 0);
        }
        else
        {
            if (Angle > 0)
                transform.Translate(Time.deltaTime * ((Speed + 0.5f + (float)Levels.speedCircles) * ((Math.Abs(FinalPosition.x - StartPosition.x) / 10) == 0 ? 1 : (Math.Abs(FinalPosition.x - StartPosition.x) / 10))) * Side * SceneManage.onPause,
                                    -Time.deltaTime * (Speed + 0.5f + (float)Levels.speedCircles) * SceneManage.onPause, 0);
            else
                transform.Translate(-Time.deltaTime * ((Speed + 0.5f + (float)Levels.speedCircles) * ((Math.Abs(FinalPosition.x - StartPosition.x) / 10) == 0 ? 1 : (Math.Abs(FinalPosition.x - StartPosition.x) / 10))) * Side * SceneManage.onPause,
                                        -Time.deltaTime * (Speed + 0.5f + (float)Levels.speedCircles) * SceneManage.onPause, 0);
        }
       
        if (gameObject.transform.position.y <= -4.5f)
        {
            if (Properties.HealthPoits > 1)
            {
                Properties.HealthPoits--;
                Destroy(gameObject);
                Debug.Log("Health - " + Properties.HealthPoits);
            }
            else
            {
                Properties.HealthPoits--;
                Destroy(gameObject);
                Debug.Log("Lose");
                Time.timeScale = 0;
            }
        }
    }
}
