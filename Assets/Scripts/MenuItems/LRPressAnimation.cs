using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LRPressAnimation : MonoBehaviour
{
    public Image LRImage;
    public Sprite LRnopress;
    public Sprite LRpress;
    public Sprite LROk;
    bool LRSwitch;
    bool timerStarted = false;
    public bool controllerAccepted = false;

    // Update is called once per frame
    void Update()
    {
        if (!controllerAccepted)
        {
            if (timerStarted == false)
            {
                timerStarted = true;
                StartCoroutine(TimeDelay()); //change image after time delay
            }
        }
        else
        {
            controllerAccepted = true;
            LRImage.sprite = LROk;
        }
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(1);

        LRSwitch = !LRSwitch;
        if (LRSwitch)
        {
            LRImage.sprite = LRnopress;
        }
        else
        {
            LRImage.sprite = LRpress;
        }
        timerStarted = false;
    }
}
