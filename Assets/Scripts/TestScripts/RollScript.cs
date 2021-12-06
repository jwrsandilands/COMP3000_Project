using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class RollScript : MonoBehaviour
{
    public float Yaxis, Xaxis;
    public Rigidbody ball;

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;
        Yaxis = gamepad.leftStick.y.ReadValue();
        Xaxis = gamepad.leftStick.x.ReadValue();

        ball.AddForce(new Vector3(1 * Xaxis, 0, 0));
        ball.AddForce(new Vector3(0, 0, 1 * Yaxis));
    }
}
