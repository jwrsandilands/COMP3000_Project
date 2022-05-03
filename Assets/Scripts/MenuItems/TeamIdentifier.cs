using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamIdentifier : MonoBehaviour
{
    public Vector3 lerpFrom;
    public Vector3 lerpTo;
    public GameObject identifier;
    public bool toggled;
    public float lerpAmount = 0.05f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (toggled)
        {
            identifier.transform.position = new Vector3 (Mathf.Lerp(identifier.transform.position.x, lerpTo.x, lerpAmount), identifier.transform.position.y, identifier.transform.position.z);
        }
        else
        {
            identifier.transform.position = new Vector3(Mathf.Lerp(identifier.transform.position.x, lerpFrom.x, lerpAmount), identifier.transform.position.y, identifier.transform.position.z);
        }
    }
}
