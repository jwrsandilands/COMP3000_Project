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
    public Text textL, textR; //get the texts to set
    public Text scoreRed, scoreBlue; //get the scores
    int scoreRedInt, scoreBlueInt;

    public GameObject winCanvas;
    public GameObject LPanel;
    public GameObject RPanel;
    public GameObject MPanel;

    private void FixedUpdate()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            minutes = Mathf.FloorToInt(time / 60);
            seconds = time % 60;
            if(minutes < 0) //make sure clock doesnt overshoot
            {
                minutes = 0;
            }
            clock = minutes + ":" + seconds.ToString("00.00"); //create clock string
            
            timeL.text = clock; //set clocks on both sides
            timeR.text = clock;
        }
        else
        {
            minutes = 0; //set everything to 0
            seconds = 0;
            clock = "0:00.00";
            timeL.text = clock;
            timeR.text = clock;

            Time.timeScale = 0; //pause time

            //get the scores
            scoreRedInt = int.Parse(scoreRed.text);
            scoreBlueInt = int.Parse(scoreBlue.text);

            //win screen conditions
            if(scoreBlueInt > scoreRedInt)
            {
                textL.text = "Blue Player Wins!";
                textR.text = "Blue Player Wins!";

                LPanel.GetComponent<Image>().color = new Color32(0, 0, 255, 174);
                RPanel.GetComponent<Image>().color = new Color32(0, 0, 255, 174);
            }
            else if(scoreBlueInt < scoreRedInt)
            {
                textL.text = "Red Player Wins!";
                textR.text = "Red Player Wins!";

                LPanel.GetComponent<Image>().color = new Color32(255, 0, 0, 174);
                RPanel.GetComponent<Image>().color = new Color32(255, 0, 0, 174);
            }
            else
            {
                textL.text = "It's a Tie!";
                textR.text = "It's a Tie!";

                LPanel.GetComponent<Image>().color = new Color32(178, 85, 129, 174);
                RPanel.GetComponent<Image>().color = new Color32(178, 85, 129, 174);
            }

            //show end screen
            winCanvas.SetActive(gameObject);
            LPanel.GetComponent<VictorySlideIn>().toggled = true;
            RPanel.GetComponent<VictorySlideIn>().toggled = true;

            MPanel.GetComponent<VictorySlideIn>().toggled = true;
        }
    }
}
