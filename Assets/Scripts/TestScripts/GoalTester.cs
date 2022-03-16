using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTester : MonoBehaviour
{
    public bool p1goal = false; //is p1 goal?
    public bool p2goal = false; //is p2 goal?


    //when something enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (p1goal == true){
            Debug.Log("Object Entered P1 goal!");
        }
        else if (p2goal == true)
        {
            Debug.Log("Object Entered P2 goal!");
        }
        else if(p1goal == true && p2goal == true)
        {
            Debug.Log("Object Entered a Shared goal!");
        }
        else
        {
            Debug.Log("Object entered a unowned goal!");
        }
    }

}
