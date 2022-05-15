using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accuracy : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;
    public UnityEngine.UI.Text txt;
    void Awake(){
        float savedAcc = PlayerPrefs.GetFloat("AccDist",slider.maxValue);
        SetAcc(savedAcc);
        slider.value = savedAcc;
        slider.onValueChanged.AddListener((float _) => SetAcc(_));
    }


    public void SetAcc(float acc)
    {
        PlayerPrefs.SetFloat("AccDist",acc);
        txt.text = acc.ToString();
    }
}
