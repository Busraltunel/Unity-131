using System;
using System.Collections;
using System.Collections.Generic;using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour
{

    [SerializeField] private TMP_TextElement volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;


public void QuitGame ()
{
    Debug.Log("QUIT!");
Application.Quit();
}





}