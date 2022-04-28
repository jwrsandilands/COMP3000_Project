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

    private bool isActive = false;

    public Material common, rare, ultra;
    public int scoreValue;
    public int cPoint, rPoint, uPoint;
    public int rarity = 0; //0 = common, 1 = rare, 2 = Ultra rare

    bool isDelay = false; //is the timer currently delaying the spawn?    

    // Run code once when the game starts
/*    void Start()
    {
        if (isActive)
        {
            //create the ball
            newBall = Instantiate(ball);

            //set rarity
            newBall.GetComponent<Renderer>().material = common;
            scoreValue = cPoint;

            //link spawner to ball
            string ballTag = this.name.ToString();
            ballTag = ballTag.Substring(ballTag.Length - 1);
            newBall.tag = "ball " + ballTag;
            ballSpawner = this.gameObject;

            //set position of the ball
            newBall.transform.position = ballSpawner.transform.position;
            newBall.transform.rotation = ballSpawner.transform.rotation;
        }
    }*/

    public bool IsActive
    {
        get { return isActive; }
        set
        {
            if (value == isActive) return;

            isActive = value;
            if (isActive)
            {
                //create the ball
                newBall = Instantiate(ball);

                //set rarity
                newBall.GetComponent<Renderer>().material = common;
                scoreValue = cPoint;

                //link spawner to ball
                string ballTag = this.name.ToString();
                ballTag = ballTag.Split(' ')[1];
                newBall.tag = "ball " + ballTag;
                ballSpawner = this.gameObject;

                //set position of the ball
                newBall.transform.position = ballSpawner.transform.position;
                newBall.transform.rotation = ballSpawner.transform.rotation;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check if the ball exists
        if (!ballExist)
        {
            //lock the co-routine while it is happening
            if(isDelay == false)
            {
                isDelay = true;
                StartCoroutine(TimeDelay()); //spawn ball after a delay
            }
        }
    }

    //spawn the ball script
    void repositionBall()
    {
        newBall.transform.position = ballSpawner.transform.position;
        newBall.transform.rotation = ballSpawner.transform.rotation;
        newBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        newBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        newBall.GetComponent<BallScoreLogger>().p1p2 = 0;

        //set rarity of the ball
        if (rarity == 0)
        {
            newBall.GetComponent<Renderer>().material = common;
            scoreValue = cPoint;
        }
        else if(rarity == 1)
        {
            newBall.GetComponent<Renderer>().material = rare;
            scoreValue = rPoint;
        }
        else if(rarity == 2)
        {
            newBall.GetComponent<Renderer>().material = ultra;
            scoreValue = uPoint;
        }

        ballExist = true;
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(3);
        isDelay = false;
        repositionBall(); //spawn the ball and set the flag
    }
}
