using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoOwnerGoal : MonoBehaviour
{
    //variables
    public BallSpawner ballSpawner; //This is a potential ball spawner target
    public GameObject[] ballSpawnerObjects; //The array of potential ball spawners

    public int scoreAwarded; //amount of score this goal awards

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
            if (other.GetComponent<BallScoreLogger>().p1p2 == 1)
            {
                Debug.Log("Player 1 Scored!"); //notify for tests

                //award points
                scoreCounterL.GetComponent<FinalScorer>().scoreP1 += scoreAwarded;
                scoreCounterR.GetComponent<FinalScorer>().scoreP1 += scoreAwarded;
            }
            else if (other.GetComponent<BallScoreLogger>().p1p2 == 2)
            {
                Debug.Log("Player 2 Scored!"); //notify for tests

                //award points
                scoreCounterL.GetComponent<FinalScorer>().scoreP2 += scoreAwarded;
                scoreCounterR.GetComponent<FinalScorer>().scoreP2 += scoreAwarded;
            }
            else
            {
                Debug.Log("Untouched Ball Scored!"); //notify for tests
            }
        }

    }
}
