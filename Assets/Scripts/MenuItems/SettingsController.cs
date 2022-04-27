using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    //corner obstacles
    public bool cornerBumper; //set bumpers Y/N
    public float cornerStrength = 1; //set bumpers x1/x2/x3
    //buttons and sliders
    public Button cornerBumperBtn; //bumper toggle
    public Slider cornerBumperSldr; //bumper strength?

    //mid obstacles
    public bool midBumper; //set bumper Y/N
    public float midStrength = 1; //set bumper x1/x2/x3
    public bool midRamp; //set ramps Y/N
    //buttons and sliders
    public Button midBumperBtn; //bumper toggle
    public Slider midBumperSldr; //bumper strength?
    public Button midRampbtn; //ramp toggle

    //goal obstacles
    public bool goalBumper; //set bumper Y/N
    public float goalStrength = 1; //set bumper x1/x2/x3
    public bool goalWarp; //set goal warp Y/N
    //buttons and sliders
    public Button goalBumperBtn; //bumper toggle
    public Slider goalBumperSldr; //bumper strength
    public Button goalWarpBtn; //warp toggle

    //ball score chance
    public int specialRarity; //set highscore ball chances 0 = 0%, 1 = 25%, 2 = 50%, 3 = 75%
    public float ballNumber; //set the number of balls to appear on the pitch at one time. 0 - 9
    //buttons
    public Button rarityBtn;
    public Slider ballNumSldr;

    //Confirm Button
    public Button confirmBtn;

    private void Start()
    {
        //corner bumpers?
        Button cbBtn = cornerBumperBtn.GetComponent<Button>();
        cbBtn.onClick.AddListener(CornerBumperToggle);

        //corner bumper strength?
        Slider cbSldr = cornerBumperSldr.GetComponent<Slider>();
        cbSldr.onValueChanged.AddListener(delegate { CornerSliderValue(cbSldr); });

        //mid bumpers?
        Button mbBtn = midBumperBtn.GetComponent<Button>();
        mbBtn.onClick.AddListener(MidBumperToggle);

        //mid bumper strength?
        Slider mbSldr = midBumperSldr.GetComponent<Slider>();
        mbSldr.onValueChanged.AddListener(delegate { MidSliderValue(mbSldr); });

        //mid ramps?
        Button mrBtn = midRampbtn.GetComponent<Button>();
        mrBtn.onClick.AddListener(MidRampToggle);

        //Goal Bumper?
        Button gbBtn = goalBumperBtn.GetComponent<Button>();
        gbBtn.onClick.AddListener(GoalBumperToggle);

        //Goal bumper strength?
        Slider gbSldr = goalBumperSldr.GetComponent<Slider>();
        gbSldr.onValueChanged.AddListener(delegate { GoalSliderValue(gbSldr); });

        //Goal Warp?
        Button gwBtn = goalWarpBtn.GetComponent<Button>();
        gwBtn.onClick.AddListener(GoalWarpToggle);

        //Ball Rarity?
        Button brBtn = rarityBtn.GetComponent<Button>();
        brBtn.onClick.AddListener(RarityToggle);

        //Ball Number?
        Slider bnSldr = ballNumSldr.GetComponent<Slider>();
        bnSldr.onValueChanged.AddListener(delegate { BallNumberValue(bnSldr); });

        Button okBtn = confirmBtn.GetComponent<Button>();
        okBtn.onClick.AddListener(ConfirmChoices);
    }

    void CornerBumperToggle()
    {
        cornerBumper = !cornerBumper;
    }

    void CornerSliderValue(Slider cbSldr)
    {
        cornerStrength = cbSldr.value;
    }

    void MidBumperToggle()
    {
        midBumper = !midBumper;
    }

    void MidSliderValue(Slider mbSldr)
    {
        midStrength = mbSldr.value;
    }

    void MidRampToggle()
    {
        midRamp = !midRamp;
    }

    void GoalBumperToggle()
    {
        goalBumper = !goalBumper;
        goalWarp = false;
    }

    void GoalSliderValue(Slider gbSldr)
    {
        goalStrength = gbSldr.value;
    }

    void GoalWarpToggle()
    {
        goalWarp = !goalWarp;
        goalBumper = false;
    }

    void RarityToggle()
    {
        if(specialRarity < 3)
        {
            specialRarity++;
        }
        else
        {
            specialRarity = 0;
        }
    }

    void BallNumberValue(Slider bnSldr)
    {
        ballNumber = bnSldr.value;
    }
    
    void ConfirmChoices()
    {
        //save all preferences
        PlayerPrefs.SetInt("cb", cornerBumper ? 1 : 0);
        PlayerPrefs.SetInt("cbs", (int)cornerStrength);

        PlayerPrefs.SetInt("mb", midBumper ? 1 : 0);
        PlayerPrefs.SetInt("mbs", (int)midStrength);
        PlayerPrefs.SetInt("mr", midRamp ? 1 : 0);

        PlayerPrefs.SetInt("gb", goalBumper ? 1 : 0);
        PlayerPrefs.SetInt("gbs", (int)goalStrength);
        PlayerPrefs.SetInt("gw", goalWarp ? 1 : 0);

        PlayerPrefs.SetInt("sr", specialRarity);
        PlayerPrefs.SetInt("bn", (int)ballNumber);


        //test log
        Debug.Log(PlayerPrefs.GetInt("cb") == 1 ? true : false);
        Debug.Log(PlayerPrefs.GetInt("cbs"));

        Debug.Log(PlayerPrefs.GetInt("mb") == 1 ? true : false);
        Debug.Log(PlayerPrefs.GetInt("mbs"));
        Debug.Log(PlayerPrefs.GetInt("mr") == 1 ? true : false);

        Debug.Log(PlayerPrefs.GetInt("gb") == 1 ? true : false);
        Debug.Log(PlayerPrefs.GetInt("gbs"));
        Debug.Log(PlayerPrefs.GetInt("gw") == 1 ? true : false);

        Debug.Log(PlayerPrefs.GetInt("sr"));
        Debug.Log(PlayerPrefs.GetInt("bn"));

        SceneManager.LoadScene("TestScene");
    }
}
