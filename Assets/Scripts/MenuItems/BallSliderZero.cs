using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSliderZero : MonoBehaviour
{
    public Button ballBtn; //the bumper button
    public Image image; //this image
    private int active; //active?

    // Update is called once per frame
    void Update()
    {
        if (0 == ballBtn.GetComponent<BallButtonColourChanger>().value)
        {
            image.color = new Color32(125, 54, 54, 255);
        }
        else image.color = Color.red;
    }
}
