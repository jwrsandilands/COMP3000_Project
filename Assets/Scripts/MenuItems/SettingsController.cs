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
    int cornerCounter = 0; //counts button presses
    //buttons and sliders
    public Button cornerBumperBtn; //bumper toggle
    public Slider cornerBumperSldr; //bumper strength?

    //mid obstacles
    public bool midBumper; //set bumper Y/N
    public float midStrength = 1; //set bumper x1/x2/x3
    public bool midRamp; //set ramps Y/N
    int midCounter = 0; //counts button presses
    //buttons and sliders
    public Button midBumperBtn; //bumper toggle
    public Slider midBumperSldr; //bumper strength?
    public Button midRampbtn; //ramp toggle

    //goal obstacles
    public bool goalBumper; //set bumper Y/N
    public float goalStrength = 1; //set bumper x1/x2/x3
    public bool goalOwned = true; //set goal ownership Y/N
    public bool goalWarp; //set goal warp Y/N
    int goalCounter = 0; //counts button presses
    //buttons and sliders
    public Button goalBumperBtn; //bumper toggle
    public Slider goalBumperSldr; //bumper strength
    public Button goalOwnedBtn; //owner toggle
    public Button goalWarpBtn; //warp toggle

    //ball score chance
    public int specialRarity; //set highscore ball chances 0 = 0%, 1 = 25%, 2 = 50%, 3 = 75%
    public float ballNumber; //set the number of balls to appear on the pitch at one time. 0 - 9
    //buttons
    public Button rarityBtn;
    public Slider ballNumSldr;

    //Confirm Button
    public Button confirmBtn;

    //team idntifiers
    public GameObject teamBlue;
    public GameObject teamRed;

    private void Start()
    {
        //corner bumpers?
        Button cbBtn = cornerBumperBtn.GetComponent<Button>();
        cbBtn.onClick.AddListener(CornerBumperToggle);
        cornerBumperBtn.GetComponent<ButtonColourChanger>().value = System.Convert.ToInt32(cornerBumper);

        //corner bumper strength?
        Slider cbSldr = cornerBumperSldr.GetComponent<Slider>();
        cbSldr.onValueChanged.AddListener(delegate { CornerSliderValue(cbSldr); });

        //mid bumpers?
        Button mbBtn = midBumperBtn.GetComponent<Button>();
        mbBtn.onClick.AddListener(MidBumperToggle);
        midBumperBtn.GetComponent<ButtonColourChanger>().value = System.Convert.ToInt32(midBumper);

        //mid bumper strength?
        Slider mbSldr = midBumperSldr.GetComponent<Slider>();
        mbSldr.onValueChanged.AddListener(delegate { MidSliderValue(mbSldr); });

        //mid ramps?
        Button mrBtn = midRampbtn.GetComponent<Button>();
        mrBtn.onClick.AddListener(MidRampToggle);
        midRampbtn.GetComponent<ButtonColourChangerOrigin>().toggled = midRamp;

        //Goal Bumper?
        Button gbBtn = goalBumperBtn.GetComponent<Button>();
        gbBtn.onClick.AddListener(GoalBumperToggle);
        goalBumperBtn.GetComponent<ButtonColourChangerVariant>().value = System.Convert.ToInt32(goalBumper);

        //Goal bumper strength?
        Slider gbSldr = goalBumperSldr.GetComponent<Slider>();
        gbSldr.onValueChanged.AddListener(delegate { GoalSliderValue(gbSldr); });

        //Goal owned?
        Button goBtn = goalOwnedBtn.GetComponent<Button>();
        goBtn.onClick.AddListener(GoalOwnerToggle);
        goalOwnedBtn.GetComponent<ButtonColourChangerOrigin>().toggled = goalOwned;

        //Goal Warp?
        Button gwBtn = goalWarpBtn.GetComponent<Button>();
        gwBtn.onClick.AddListener(GoalWarpToggle);
        goalWarpBtn.GetComponent<ButtonColourChangerVariant>().value = System.Convert.ToInt32(goalWarp);

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
        if (cornerCounter < 3)
        {
            cornerCounter++;
            cornerBumper = true;
        }
        else
        {
            cornerCounter = 0;

            cornerBumperSldr.value = 1;
            cornerStrength = 1;
            cornerBumper = false;
        }
    }

    void CornerSliderValue(Slider cbSldr)
    {
        cornerStrength = cbSldr.value;
    }

    void MidBumperToggle()
    {
        if (midCounter < 3)
        {
            midCounter++;
            midBumper = true;
        }
        else
        {
            midCounter = 0;

            midBumperSldr.value = 1;
            midStrength = 1;
            midBumper = false;
        }
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
        goalWarp = false;
        if (goalCounter < 3)
        {
            goalCounter++;
            goalBumper = true;
            goalBumperSldr.value = goalCounter;

            goalBumperBtn.GetComponent<ButtonColourChangerVariant>().value = goalCounter;
            goalWarpBtn.GetComponent<ButtonColourChangerVariant>().value = 0;

            if (goalCounter == 1)
            {
                goalBumperBtn.GetComponentInChildren<Text>().text = "Bumpers\n(Power x1)";
            }
            else if (goalCounter == 2)
            {
                goalBumperBtn.GetComponentInChildren<Text>().text = "Bumpers\n(Power x2)";
            }
            else
            {
                goalBumperBtn.GetComponentInChildren<Text>().text = "Bumpers\n(Power x3)";
            }
        }
        else
        {
            goalCounter = 0;
            goalBumperBtn.GetComponentInChildren<Text>().text = "Bumpers\n(Off)";
            goalBumperSldr.value = 1;
            goalStrength = 1;
            goalBumper = false;
            goalBumperBtn.GetComponent<ButtonColourChangerVariant>().value = 0;
        }
    }

    void GoalSliderValue(Slider gbSldr)
    {
        goalStrength = gbSldr.value;
    }

    void GoalOwnerToggle()
    {
        goalOwned = !goalOwned;
        teamBlue.GetComponent<TeamIdentifier>().toggled = goalOwned;
        teamRed.GetComponent<TeamIdentifier>().toggled = goalOwned;
    }

    void GoalWarpToggle()
    {
        goalWarp = !goalWarp;
        goalBumper = false;
        goalBumperBtn.GetComponentInChildren<Text>().text = "Bumpers\n(Off)";
        goalCounter = 0;

        goalWarpBtn.GetComponent<ButtonColourChangerVariant>().value = goalWarp ? 1 : 0;
        goalBumperBtn.GetComponent<ButtonColourChangerVariant>().value = 0;

        if (goalBumper == false)
        {
            goalBumperSldr.value = 1;
            goalStrength = 1;
            goalBumperSldr.enabled = false;
        }
        else
        {
            goalBumperSldr.enabled = true;
        }
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
        PlayerPrefs.SetInt("go", goalOwned ? 1 : 0);
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
        Debug.Log(PlayerPrefs.GetInt("go") == 1 ? true : false);
        Debug.Log(PlayerPrefs.GetInt("gw") == 1 ? true : false);

        Debug.Log(PlayerPrefs.GetInt("sr"));
        Debug.Log(PlayerPrefs.GetInt("bn"));

        Debug.Log("----Moving Scene!----");

        SceneManager.LoadScene("TestScene");
    }
}
