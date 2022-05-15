using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timeText;
    public float timeValue = 3.99f;
    public float referenceValue;
    void Start()
    {
        referenceValue = Time.deltaTime;
    }
    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= (referenceValue - Time.deltaTime);
        } else {
            timeValue = 0;
            timeText.gameObject.SetActive(false);
        }
        DisplayTime(timeValue);
        
    }

    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay = 0;
        }
        float seconds = Mathf.FloorToInt(timeToDisplay %60);
        timeText.text = seconds + " seconds";
    }
}
