using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    //variables
    public BallSpawner ballSpawner; //This is a potential ball spawner target
    public GameObject[] ballSpawnerObjects; //The array of potential ball spawners

    public bool p1goal = false; //is p1 goal?
    public bool p2goal = false; //is p2 goal?

    public int scoreAwarded = 100; //amount of score this goal awards

    public GameObject scoreCounterL; //P1 or P2 scoring?
    public GameObject scoreCounterR;

    //when something enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        //if the collider object is the ball
        if (other.tag.StartsWith("ball"))
        {
            int n = int.Parse(other.tag.Substring(5));
            ballSpawner = ballSpawnerObjects[n].GetComponent<BallSpawner>();
            ballSpawner.ballExist = false;
            scoreAwarded = ballSpawner.scoreValue;

            //check who to give points
            if (p1goal && !p2goal)
            {
                Debug.Log("Ball Entered P1 goal!"); //notify for tests

                //award points
                scoreCounterL.GetComponent<FinalScorer>().scoreP2 += scoreAwarded;
                scoreCounterR.GetComponent<FinalScorer>().scoreP2 += scoreAwarded;
            }
            else if (!p1goal && p2goal)
            {
                Debug.Log("Ball Entered P2 goal!"); //notify for tests

                //award points
                scoreCounterL.GetComponent<FinalScorer>().scoreP1 += scoreAwarded;
                scoreCounterR.GetComponent<FinalScorer>().scoreP1 += scoreAwarded;
            }
            else if (p1goal && p2goal)
            {
                Debug.Log("Ball Entered a Shared goal!"); //notify for tests

                //award points
                scoreCounterL.GetComponent<FinalScorer>().scoreP2 += scoreAwarded;
                scoreCounterL.GetComponent<FinalScorer>().scoreP1 += scoreAwarded;
                scoreCounterR.GetComponent<FinalScorer>().scoreP2 += scoreAwarded;
                scoreCounterR.GetComponent<FinalScorer>().scoreP1 += scoreAwarded;
            }
            else
            {
                Debug.Log("Ball entered a unowned goal!"); //notify for tests
            }
        }

    }
}
