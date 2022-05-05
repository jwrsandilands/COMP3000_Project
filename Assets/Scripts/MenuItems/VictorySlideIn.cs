using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySlideIn : MonoBehaviour
{
    //public RectTransform lerpFrom;
    public RectTransform lerpTo;
    public GameObject identifier;
    public bool toggled;
    public float lerpAmount = 0.05f;

    // Update is called once per frame
    void Update()
    {
        if (toggled)
        {
            identifier.transform.position = new Vector3(Mathf.Lerp(identifier.transform.position.x, lerpTo.position.x, lerpAmount), Mathf.Lerp(identifier.transform.position.y, lerpTo.position.y, lerpAmount), Mathf.Lerp(identifier.transform.position.z, lerpTo.position.z, lerpAmount));
        }
    }
}
