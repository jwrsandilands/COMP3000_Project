using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public float BrakeTorque; // brakeforce to be applied when braking

    void Start()
    {

    }

    public Gamepad player;

    public void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 steer = player.leftStick.ReadValue();
            float drive = player.rightTrigger.ReadValue();
            float reverse = player.leftTrigger.ReadValue();
            float brake = player.aButton.ReadValue();
            Debug.Log(brake);

            float motor = maxMotorTorque * (drive - reverse);
            float steering = maxSteeringAngle * steer.x;
            float braking = BrakeTorque * brake;

            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.steering)
                {
                    //Steer with all wheels tied to the "Steering"
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }
                if (axleInfo.motor)
                {
                    //accelerate with all wheels tied to the "motor"
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;

                    //Braking and powersliding
                    if (steering <= 0)
                    {
                        axleInfo.leftWheel.brakeTorque = braking;
                    }
                    if (steering >= 0)
                    {
                        axleInfo.rightWheel.brakeTorque = braking;
                    }
                    
                }
            }
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
