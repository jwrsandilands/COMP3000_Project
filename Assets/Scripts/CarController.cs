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

    public float angleLimit = 15f; // variable to limit amount of tilt car can undergo

    public int playerNumber; //get the number of this car's player
    public Gamepad player; //set controller associated with this car.

    void Start()
    {
        CarRigidbody.centerOfMass = new Vector3(0.0f, massPos, 0.0f); // set center of mass
    }

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
                    
                    if (brake !<= 0)
                    {
                        axleInfo.leftWheel.brakeTorque = braking;
                        axleInfo.rightWheel.brakeTorque = braking;
                    }
                }
            }
        }
        //clamp angle so car cannot flip
        this.transform.eulerAngles = new Vector3(angleClamp(this.transform.eulerAngles.x, angleLimit), this.transform.eulerAngles.y, angleClamp(this.transform.eulerAngles.z, angleLimit));
    }

    //Method that ensures failsafe when clamping angles
    public float angleClamp(float angle, float clamp)
    {
        //create the minimum and maximum clamp variables
        float min = -clamp;
        float max = clamp;

        //if an angle is in a region that may cause error...
        if (angle < 90 || angle > 270) 
        {
            //convert each angles to be within 0 to 360 with 180 as the mid-point.
            if (angle > 180) angle -= 360;  
            if (max > 180) max -= 360;
            if (min > 180) min -= 360;
        }

        //now use the inbuilt clamping function
        angle = Mathf.Clamp(angle, min, max);

        //if the angle is negative, convert is to be within 0 to 360
        if (angle < 0)
        {
            angle += 360;  
        }

        return angle;
    } //ANGLECLAMP END
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}


