using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public float minutes, seconds; 
    string clock; //the assembled clock
    public Text timeL, timeR;

    public GameObject winCanvas;

    private void FixedUpdate()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            minutes = Mathf.FloorToInt(time / 60);
            seconds = time % 60;
            if(minutes < 0)
            {
                minutes = 0;
            }
            clock = minutes + ":" + seconds.ToString("00.00");
            
            timeL.text = clock;
            timeR.text = clock;
        }
        else
        {
            minutes = 0;
            seconds = 0;
            clock = "0:00.00";
            timeL.text = clock;
            timeR.text = clock;

            Time.timeScale = 0;
            winCanvas.SetActive(gameObject);
        }
    }
}
