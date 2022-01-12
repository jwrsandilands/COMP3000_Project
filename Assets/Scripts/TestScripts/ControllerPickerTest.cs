using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPickerTest : MonoBehaviour
{
    public bool p1, p2;
    public GameObject ball1, ball2;
    Gamepad player1, player2;

    // Update is called once per frame
    void Update()
    {
        if (player1 == null && Gamepad.current.leftShoulder.ReadValue() == 1 && Gamepad.current.rightShoulder.ReadValue() == 1)
        {
            player1 = Gamepad.current;
            p1 = true;
            ball1.GetComponent<CarController>().player = player1;
        }
        else if (player2 == null && Gamepad.current != player1 && Gamepad.current.leftShoulder.ReadValue() == 1 && Gamepad.current.rightShoulder.ReadValue() == 1)
        {
            player2 = Gamepad.current;
            p2 = true;
            ball2.GetComponent<CarController>().player = player2;
        }
    }
}
