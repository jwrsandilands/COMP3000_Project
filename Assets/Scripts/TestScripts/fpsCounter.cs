using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsCounter : MonoBehaviour
{
    public int avgFrameRate;
    public Text display_Text;

    // Update is called once per frame
    public void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        display_Text.text = "FPS Counter: " + avgFrameRate.ToString();
    }
}
