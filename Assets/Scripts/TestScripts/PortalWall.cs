using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalWall : MonoBehaviour
{
    public string playerTag = "Player";

/*    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == playerTag)
        {
            Rigidbody otherRB = collision.rigidbody;

            Debug.Log("Car has Quantumn Tunnelled!");

            Debug.Log(collision.GetContact(0).point);

            otherRB.position = new Vector3(-collision.GetContact(0).point.x, collision.GetContact(0).point.y, collision.GetContact(0).point.z);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == playerTag)
        {
            Rigidbody otherRB = other.attachedRigidbody;

            Debug.Log("Car has Quantumn Tunnelled!");
            Vector3 dir = other.transform.position;
            Debug.Log(dir);
            Debug.Log(new Vector3(-dir.x * 0.95f, dir.y, dir.z));

            otherRB.position = new Vector3(-dir.x * 0.95f, dir.y, dir.z);

        }
    }
}
