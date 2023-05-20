using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOnLose : MonoBehaviour //Меню после пройгрыша
{
    [SerializeField] public GameObject LoseMenu;
    void Update()
    {
        if (Properties.HealthPoits == 0)
        {
            LoseMenu.SetActive(true);
        }
    }
}
