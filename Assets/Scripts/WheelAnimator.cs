using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAnimator : MonoBehaviour
{
    public GameObject wheel;
    Quaternion rotation;

    // Update is called once per frame
    void Update()
    {
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, wheel.GetComponent<WheelCollider>().steerAngle - this.transform.localEulerAngles.z, this.transform.localEulerAngles.z);

        this.transform.Rotate((wheel.GetComponent<WheelCollider>().rpm / 60 * 360 * Time.deltaTime) / 7.6f, 0, 0);
    
    }
}
