using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallButtonColourChanger : MonoBehaviour
{
    public int value = 0; //toggled?
    public Button Btn; //button to toggle colour of
    public Slider raritySlider; //slider

    // Start is called before the first frame update
    void Start()
    {
        Button button = Btn.GetComponent<Button>();
        button.onClick.AddListener(Toggle);
    }

    void Toggle()
    {
        if (value < 3)
        {
            value++;
            if(value == 1)
            {
                Btn.GetComponentInChildren<Text>().text = "Special\n(Rare)";
                raritySlider.value = 1;
            }
            else if(value == 2)
            {
                Btn.GetComponentInChildren<Text>().text = "Special\n(Common)";
                raritySlider.value = 2;
            }
            else
            {
                Btn.GetComponentInChildren<Text>().text = "Special\n(Constant)";
                raritySlider.value = 3;
            }
        }
        else
        {
            value = 0;
            Btn.GetComponentInChildren<Text>().text = "Special\n(Off)";
            raritySlider.value = 1;
        }
    }

    private void Update()
    {
        if (value > 0)
        {
            ColorBlock colorer = Btn.colors;
            colorer.normalColor = new Color32(255, 255, 255, 255);
            colorer.highlightedColor = new Color32(245, 245, 245, 255);
            colorer.pressedColor = new Color32(200, 200, 200, 255);
            colorer.selectedColor = new Color32(245, 245, 245, 255);
            colorer.disabledColor = new Color32(245, 245, 245, 255);
            Btn.colors = colorer;
        }
        else
        {
            ColorBlock colorer = Btn.colors;
            colorer.normalColor = new Color32(150, 150, 150, 255);
            colorer.highlightedColor = new Color32(190, 190, 190, 255);
            colorer.pressedColor = new Color32(145, 145, 145, 255);
            colorer.selectedColor = new Color32(190, 190, 190, 255);
            colorer.disabledColor = new Color32(190, 190, 190, 255);
            Btn.colors = colorer;
        }
    }
}
