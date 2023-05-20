using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCircles : MonoBehaviour
{
    [SerializeField] public static List<GameObject> circles = new();
    [SerializeField] private GameObject Circle;
    public static DateTime timeOfStart = DateTime.Now;
    void Start()
    {
        Debug.Log(Levels.speedCircles + " " + Levels.timeOfCreating);
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine() //Создание шариков с определённой позицией, скоростью и скоростью появления
    { 
        circles.Add(Instantiate(Circle, Circle.transform.position, Quaternion.identity));

        yield return new WaitForSeconds((float)Levels.timeOfCreating);

        circles.RemoveAll(s => s == null);

        StartCoroutine(ExampleCoroutine());

    }
}
