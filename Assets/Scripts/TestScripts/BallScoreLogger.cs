using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScoreLogger : MonoBehaviour
{
    public int p1p2 = 0; //None = 0, p1 = 1, p2 = 2;
    public string playerTag = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == playerTag)
        {
            if (collision.rigidbody.GetComponent<CarController>().playerNumber == 1)
            {
                Debug.Log("Player 1 hit the ball!");
                p1p2 = 1;
            }
            else if (collision.rigidbody.GetComponent<CarController>().playerNumber == 2)
            {
                Debug.Log("Player 2 hit the ball!");
                p1p2 = 2;
            }
        }
    }
}
