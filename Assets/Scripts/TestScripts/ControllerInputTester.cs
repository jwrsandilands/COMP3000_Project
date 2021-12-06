using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ControllerInputTester : MonoBehaviour
{
    public float Yaxis, Xaxis;
    public float A, B, X, Y;

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;
        Yaxis = gamepad.leftStick.y.ReadValue();
        Xaxis = gamepad.leftStick.x.ReadValue();
        A = gamepad.buttonSouth.ReadValue();
        B = gamepad.buttonEast.ReadValue();
        X = gamepad.buttonWest.ReadValue();
        Y = gamepad.buttonNorth.ReadValue();
    }
}
