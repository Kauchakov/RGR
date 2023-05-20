using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
public class MenuOnEsc : MonoBehaviour //Менюшка паузы
{
    private bool isOn = true;
    [SerializeField] public GameObject menu, soundOn, soundOff;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Properties.HealthPoits != 0)
        {
            if (menu.activeSelf == false)
            {
                menu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            { 
                menu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
    public void Resume()
    {

    }
    public void Sound()
    {
        if (isOn)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
            isOn = false;
            AudioListener.volume = 0f;
        }
        else
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
            isOn = true;
            AudioListener.volume = 1f;
        }
    }
}
