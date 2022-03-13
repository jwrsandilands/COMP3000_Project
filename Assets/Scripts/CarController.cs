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
    
    public Rigidbody CarRigidbody; // get rigid body of car
    public float massPos = -0.3f; // y position of local center of mass

    public float angleLimit = 15f; // variable to limit amout of tilt car can undergo

    void Start()
    {
        CarRigidbody.centerOfMass = new Vector3(0.0f, massPos, 0.0f); // set center of mass
        
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
        //clamp angle so car cannot flip
        this.transform.eulerAngles = new Vector3(angleClamp(this.transform.eulerAngles.x, angleLimit), this.transform.eulerAngles.y, angleClamp(this.transform.eulerAngles.z, angleLimit));
    }

    public float angleClamp(float angle, float clamp)
    {
        float min = -clamp;
        float max = clamp;

        if (angle < 90 || angle > 270) // if angle in the critic region...
        {
            if (angle > 180) angle -= 360;  // convert all angles to -180..+180
            if (max > 180) max -= 360;
            if (min > 180) min -= 360;
        }

        angle = Mathf.Clamp(angle, min, max);

        if (angle < 0)
        {
            angle += 360;  // if angle negative, convert to 0..360
        }

        return angle;
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


