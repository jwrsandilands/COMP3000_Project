using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    //variables
    public GameObject ball; //get the ball object
    public GameObject newBall; //instantiated ball
    public GameObject ballSpawner; //ballSpawner
    public bool ballExist = true; //ball does exists by default

    // Run code once when the game starts
    void Start()
    {
        newBall = Instantiate(ball);
        string ballTag = this.name.ToString();
        ballTag = ballTag.Substring(ballTag.Length - 1);
        newBall.tag = "ball " + ballTag;
        ballSpawner = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //check if the ball exists
        if (!ballExist)
        {
            repositionBall(); //spawn the ball and set the flag
        }
    }

    //spawn the ball script
    void repositionBall()
    {
        newBall.transform.position = ballSpawner.transform.position;
        newBall.transform.rotation = ballSpawner.transform.rotation;
        newBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        newBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ballExist = true;
    }
}
