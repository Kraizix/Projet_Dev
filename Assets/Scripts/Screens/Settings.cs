using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle Auto;
    public Toggle NoFail;
    public Toggle Fullscreen;

    void Start()
    {
        if(Auto)
        {
            Auto.isOn = PlayerPrefs.GetInt("auto", 0) == 1;
            NoFail.isOn = PlayerPrefs.GetInt("noFail", 0) == 1;
        }
        Fullscreen.isOn = Screen.fullScreen;
    }
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetAuto(bool isAuto)
    {
        if(isAuto){
            NoFail.isOn = false;
            PlayerPrefs.SetInt("noFail",0);
        }
        PlayerPrefs.SetInt("auto",isAuto ? 1 : 0);
    }
    public void SetNoFail(bool isNoFail)
    {
        if(isNoFail){
            Auto.isOn = false;
            PlayerPrefs.SetInt("auto",0);
        }  
        PlayerPrefs.SetInt("noFail",isNoFail ? 1 : 0);
    }
     
}
