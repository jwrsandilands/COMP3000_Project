using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsRetriever : MonoBehaviour
{
    private bool cb, mb, mr, gb, go, gw; //corner bumper, mid bumper, mid ramps, goal bumper, goal owners, goal warps
    private int cbs, mbs, gbs, sr, bn; //corner bumper strength, mid bumper strength, goal bumper strength, special rarity, ball number
    public BallSpawner[] ballSpawners;
    public GameObject[] bumpers;
    public GameObject[] ramps;
    public GameObject[] goals;
    public GameObject arenaFrame;
    public Material goalOwned;

    int n;
    int cCounter, commonsExists;
    int rCounter, raresExists;
    int uCounter, ultrasExists;
    bool[] previouslyExists;


    // Start is called before the first frame update
    void Start()
    {
        //test log
        Debug.Log(PlayerPrefs.GetInt("cb") == 1 ? true : false);
        Debug.Log(PlayerPrefs.GetInt("cbs"));

        Debug.Log(PlayerPrefs.GetInt("mb") == 1 ? true : false);
        Debug.Log(PlayerPrefs.GetInt("mbs"));
        Debug.Log(PlayerPrefs.GetInt("mr") == 1 ? true : false);

        Debug.Log(PlayerPrefs.GetInt("gb") == 1 ? true : false);
        Debug.Log(PlayerPrefs.GetInt("gbs"));
        Debug.Log(PlayerPrefs.GetInt("go") == 1 ? true : false);
        Debug.Log(PlayerPrefs.GetInt("gw") == 1 ? true : false);


        Debug.Log(PlayerPrefs.GetInt("sr"));
        Debug.Log(PlayerPrefs.GetInt("bn"));

        if(PlayerPrefs.HasKey("cb"))
        {
            //load variables from the PlayerPrefs
            cb = PlayerPrefs.GetInt("cb") == 1 ? true : false; //
            mb = PlayerPrefs.GetInt("mb") == 1 ? true : false; //
            mr = PlayerPrefs.GetInt("mr") == 1 ? true : false; //
            gb = PlayerPrefs.GetInt("gb") == 1 ? true : false; //
            go = PlayerPrefs.GetInt("go") == 1 ? true : false; //
            gw = PlayerPrefs.GetInt("gw") == 1 ? true : false; //

            cbs = PlayerPrefs.GetInt("cbs"); //
            mbs = PlayerPrefs.GetInt("mbs"); //
            gbs = PlayerPrefs.GetInt("gbs"); //
            sr = PlayerPrefs.GetInt("sr"); //
            bn = PlayerPrefs.GetInt("bn"); //
        }
        else
        {
            //use preset defaults
            cb = true;
            mb = false;
            mr = false;
            gb = true;
            go = false;
            gw = false;
            cbs = 1;
            mbs = 1;
            sr = 1;
            bn = 4;
        }

        //set up array variables
        previouslyExists = new bool[bn];

        //set if a spawner is active using predefined patterns
        //0 top mid, 1 bottom mid, 2  upper left, 3 lower left, 4 upper right, 5 lower right
        //6 top left, 7 bottom left, 8 top right, 9 bottom right, 10 mid mid
        switch (bn - 1)
        {
            case 0:
                ballSpawners[10].IsActive = true;
                break;
            case 1:
                ballSpawners[0].IsActive = true;
                ballSpawners[1].IsActive = true;
                break;
            case 2:
                ballSpawners[0].IsActive = true;
                ballSpawners[1].IsActive = true;
                ballSpawners[10].IsActive = true;
                break;
            case 3:
                ballSpawners[2].IsActive = true;
                ballSpawners[3].IsActive = true;
                ballSpawners[4].IsActive = true;
                ballSpawners[5].IsActive = true;
                break;
            case 4:
                ballSpawners[10].IsActive = true; 
                ballSpawners[2].IsActive = true;
                ballSpawners[3].IsActive = true;
                ballSpawners[4].IsActive = true;
                ballSpawners[5].IsActive = true;
                break;
            case 5:
                ballSpawners[0].IsActive = true;
                ballSpawners[1].IsActive = true;
                ballSpawners[6].IsActive = true;
                ballSpawners[7].IsActive = true;
                ballSpawners[8].IsActive = true;
                ballSpawners[9].IsActive = true;
                break;
            case 6:
                ballSpawners[0].IsActive = true;
                ballSpawners[1].IsActive = true;
                ballSpawners[10].IsActive = true; 
                ballSpawners[6].IsActive = true;
                ballSpawners[7].IsActive = true;
                ballSpawners[8].IsActive = true;
                ballSpawners[9].IsActive = true;
                break;
            case 7:
                ballSpawners[2].IsActive = true;
                ballSpawners[3].IsActive = true;
                ballSpawners[4].IsActive = true;
                ballSpawners[5].IsActive = true;
                ballSpawners[6].IsActive = true;
                ballSpawners[7].IsActive = true;
                ballSpawners[8].IsActive = true;
                ballSpawners[9].IsActive = true;
                break;
            case 8:
                ballSpawners[10].IsActive = true; 
                ballSpawners[2].IsActive = true;
                ballSpawners[3].IsActive = true;
                ballSpawners[4].IsActive = true;
                ballSpawners[5].IsActive = true;
                ballSpawners[6].IsActive = true;
                ballSpawners[7].IsActive = true;
                ballSpawners[8].IsActive = true;
                ballSpawners[9].IsActive = true;
                break;
            case 9:
                ballSpawners[0].IsActive = true;
                ballSpawners[1].IsActive = true;
                ballSpawners[2].IsActive = true;
                ballSpawners[3].IsActive = true;
                ballSpawners[4].IsActive = true;
                ballSpawners[5].IsActive = true;
                ballSpawners[6].IsActive = true;
                ballSpawners[7].IsActive = true;
                ballSpawners[8].IsActive = true;
                ballSpawners[9].IsActive = true;
                break;
        }

        //set if bumpers are on or not
        //0 top left, 1 bottom left, 2 top right, 3 bottom right, 4 left goal, 5 right goal
        //6 left warp, 7 right warp, 8 left wall, 9 right wall, 10 is Mid upper, 11 mid lower
        //12 mid left, 13 mid right
        if (cb) //corner bumpers? 
        {
            //set corner bumpers as active
            bumpers[0].SetActive(true);
            bumpers[1].SetActive(true);
            bumpers[2].SetActive(true);
            bumpers[3].SetActive(true);

            //set corner bumper strengths
            bumpers[0].GetComponent<Bumper>().bounceForceBall *= cbs;
            bumpers[0].GetComponent<Bumper>().bounceForceCar *= cbs;
            bumpers[1].GetComponent<Bumper>().bounceForceBall *= cbs;
            bumpers[1].GetComponent<Bumper>().bounceForceCar *= cbs;
            bumpers[2].GetComponent<Bumper>().bounceForceBall *= cbs;
            bumpers[2].GetComponent<Bumper>().bounceForceCar *= cbs;
            bumpers[3].GetComponent<Bumper>().bounceForceBall *= cbs;
            bumpers[3].GetComponent<Bumper>().bounceForceCar *= cbs;
        }

        if (mb) //mid bumers?
        {
            //set mid bumpers as active
            bumpers[10].SetActive(true);
            bumpers[11].SetActive(true);
            bumpers[12].SetActive(true);
            bumpers[13].SetActive(true);
        }

        
        if (gb) //goal bumpers?
        {
            //set goal bumpers as active
            bumpers[4].SetActive(true);
            bumpers[5].SetActive(true);
            bumpers[8].SetActive(false); //bumpers 8 and 9 are actually collision objects that need to be disabled
            bumpers[9].SetActive(false);

            //set goal bumper strengths (not for balls they cant collide with these)
            bumpers[4].GetComponent<Bumper>().bounceForceCar *= gbs;
            bumpers[5].GetComponent<Bumper>().bounceForceCar *= gbs;
        }
        else if(gw) //goal warps?
        {
            //set goal warps as active
            bumpers[6].SetActive(true); //bumpers 6 and 7 are actually warper objects
            bumpers[7].SetActive(true);
            bumpers[8].SetActive(false); //bumpers 8 and 9 are actually collision objects that need to be disabled
            bumpers[9].SetActive(false);

            //set mid bumper strengths
            bumpers[10].GetComponent<Bumper>().bounceForceBall *= mbs;
            bumpers[10].GetComponent<Bumper>().bounceForceCar *= mbs;
            bumpers[11].GetComponent<Bumper>().bounceForceBall *= mbs;
            bumpers[11].GetComponent<Bumper>().bounceForceCar *= mbs;
            bumpers[12].GetComponent<Bumper>().bounceForceBall *= mbs;
            bumpers[12].GetComponent<Bumper>().bounceForceCar *= mbs;
            bumpers[13].GetComponent<Bumper>().bounceForceBall *= mbs;
            bumpers[13].GetComponent<Bumper>().bounceForceCar *= mbs;
        }

        //set ramps
        if (mr) //mid ramps?
        {
            //set mid ramps as active
            ramps[0].SetActive(true);
            ramps[1].SetActive(true);
        }

        //set goals owned
        if (go)
        {
            //set owned goals as the active goals
            goals[0].SetActive(true);
            goals[1].SetActive(true);

            goals[2].SetActive(false);
            goals[3].SetActive(false);

            arenaFrame.GetComponent<Renderer>().material = goalOwned;
        }
        else
        {
            //set unowned goals as the active goals
            goals[2].SetActive(true);
            goals[3].SetActive(true);

            goals[0].SetActive(false);
            goals[1].SetActive(false);
        }

    }

    private void Update()
    {
        //use the update as a while loop to monitor ball numbers
        n++;
        if (n >= bn) 
        { 
            n = 0;

            commonsExists = cCounter;
            raresExists = rCounter;
            ultrasExists = uCounter;

            //Debug.Log("commons: " + commonsExists + " rares: " + raresExists + " ultras: " + ultrasExists);

            cCounter = 0;
            rCounter = 0;
            uCounter = 0;
        }

        //if common ball
        if(ballSpawners[n].rarity == 0)
        {
            //increase common counter
            cCounter++;
            //check if ball is missing
            if (!ballSpawners[n].ballExist)
            {
                //if ball was just scored
                if(previouslyExists[n] != ballSpawners[n].ballExist)
                {
                    Debug.Log("Common Ball Scored");

                    //create a random chance for a rare and Ultrarare ball
                    if (commonsExists > bn / 1.2f)
                    {
                        int rchance = Random.Range(0, 4);
                        int uchance = Random.Range(0, 8);
                        if (rchance < sr)
                        {
                            if (uchance < sr)
                            {
                                ballSpawners[n].rarity = 2;
                            }
                            else
                            {
                                ballSpawners[n].rarity = 1;
                            }
                        }
                    }
                }
            }
        }
        else if (ballSpawners[n].rarity == 1)
        {
            rCounter++;
            if (!ballSpawners[n].ballExist)
            {
                if (previouslyExists[n] != ballSpawners[n].ballExist)
                {
                    Debug.Log("Rare Ball Scored");

                    ballSpawners[n].rarity = 0;

                    if (commonsExists == bn - 2)
                    {
                        int rchance = Random.Range(0, 6);
                        int uchance = Random.Range(0, 12);
                        if (rchance < sr)
                        {
                            if (uchance < sr)
                            {
                                ballSpawners[n].rarity = 2;
                            }
                            else
                            {
                                ballSpawners[n].rarity = 1;
                            }
                        }
                    }
                }
            }
        }
        else if(ballSpawners[n].rarity == 2)
        {
            uCounter++;
            if (!ballSpawners[n].ballExist)
            {
                if (previouslyExists[n] != ballSpawners[n].ballExist)
                {
                    Debug.Log("Ultra Ball Scored");

                    ballSpawners[n].rarity = 0;

                    if (commonsExists == bn - 1)
                    {
                        int rchance = Random.Range(0, 8);
                        int uchance = Random.Range(0, 16);
                        if (rchance < sr)
                        {
                            if (uchance < sr)
                            {
                                ballSpawners[n].rarity = 2;
                            }
                            else
                            {
                                ballSpawners[n].rarity = 1;
                            }
                        }
                    }
                }
            }
        }

        previouslyExists[n] = ballSpawners[n].ballExist;
    }
}
