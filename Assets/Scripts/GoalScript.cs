using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    //variables
    public Collider ball; //this is the ball collider
    
    public bool p1goal = false; //is p1 goal?
    public bool p2goal = false; //is p2 goal?

    public float scoreAwarded; //amount of score this goal awards


    //when something enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        //if the collider object is the ball
        if (other == ball)
        {
            //check who to give points
            if (p1goal == true && p2goal != true)
            {
                Debug.Log("Ball Entered P1 goal!"); //notify for tests
                //award points
            }
            else if (p1goal != true && p2goal == true)
            {
                Debug.Log("Ball Entered P2 goal!"); //notify for tests
                //award points
            }
            else if (p1goal == true && p2goal == true)
            {
                Debug.Log("Ball Entered a Shared goal!"); //notify for tests
                //award points
            }
            else
            {
                Debug.Log("Ball entered a unowned goal!"); //notify for tests
            }
        }

    }
}
