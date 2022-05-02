using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColourChanger : MonoBehaviour
{
    public bool toggled = false; //toggled?
    public Button Btn; //button to toggle colour of


    // Start is called before the first frame update
    void Start()
    {
        Button button = Btn.GetComponent<Button>();
        button.onClick.AddListener(Toggle);
    }

    void Toggle()
    {
        toggled = !toggled;
    }

    private void Update()
    {
        if (toggled)
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
