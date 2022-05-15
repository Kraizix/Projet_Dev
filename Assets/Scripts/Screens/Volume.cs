using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{

    public UnityEngine.UI.Slider slider;
    public UnityEngine.Audio.AudioMixer mixer;
    public string parameterName;
    void Awake(){
        float savedVol = PlayerPrefs.GetFloat(parameterName,slider.maxValue);
        SetVolume(savedVol);
        slider.value = savedVol;
        slider.onValueChanged.AddListener((float _) => SetVolume(_));
    }


    public void SetVolume(float volume)
    {
        mixer.SetFloat(parameterName,volume);
        PlayerPrefs.SetFloat(parameterName,volume);
    }
}
