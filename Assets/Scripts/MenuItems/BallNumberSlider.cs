using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallNumberSlider : MonoBehaviour
{
    public Slider thisSlider;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        Slider slider = thisSlider.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { SliderValueChange(); });
    }

    void SliderValueChange()
    {
        text.text = "Number of Balls\n(" + thisSlider.value + ")";
    }
}
