using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public string playerTag;
    public string ballTag;
    public float bounceForceCar = 100000;
    public float bounceForceBall = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == playerTag)
        {
            Rigidbody otherRB = collision.rigidbody;

            Debug.Log("Bumper Struck By Car!");

            //Vector3 dir = collision.transform.position - transform.position;
            //otherRB.AddForce(dir * bounceForce);

            otherRB.AddExplosionForce(bounceForceCar, collision.GetContact(0).point, 10);
        }
        else if(collision.transform.tag.Substring(0,4) == ballTag)
        {
            Rigidbody otherRB = collision.rigidbody;

            Debug.Log("Bumper Struck By Ball!");

            //Vector3 dir = collision.transform.position - transform.position;
            //otherRB.AddForce(dir * bounceForce);
            
            otherRB.AddExplosionForce(bounceForceBall, collision.GetContact(0).point, 10);
        }
    }
}
