using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSliderZero2 : MonoBehaviour
{
    public Button bumperBtn; //the bumper button
    public Image image; //this image
    private bool active; //active?

    // Update is called once per frame
    void Update()
    {
        if (bumperBtn.GetComponent<ButtonColourChangerOrigin>().toggled)
        {
            IsActive = true;
        }
        else IsActive = false;
    }

    //only do this when Active is toggled
    private bool IsActive
    {
        get { return active; }
        set
        {
            if (value == active) return;

            active = value;
            if (!active)
            {
                image.color = new Color32(125, 54, 54, 255);
            }
            else
            {
                image.color = Color.red;
            }
        }
    }
}
