using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsRetriever : MonoBehaviour
{
    public bool cb, mb, mr, gb, go, gw; //corner bumper, mid bumper, mid ramps, goal bumper, goal owners, goal warps
    public int cbs, mbs, gbs, sr, bn; //corner bumper strength, mid bumper strength, goal bumper strength, special rarity, ball number
    public BallSpawner[] ballSpawners;
    int nSpawners;

    int n;
    int cCounter, commonsExists;
    int rCounter, raresExists;
    int uCounter, ultrasExists;
    bool[] previouslyExists;


    // Start is called before the first frame update
    void Start()
    {
        nSpawners = ballSpawners.Length;
        previouslyExists = new bool[nSpawners];

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
            cb = PlayerPrefs.GetInt("cb") == 1 ? true : false;
            mb = PlayerPrefs.GetInt("mb") == 1 ? true : false;
            mr = PlayerPrefs.GetInt("mr") == 1 ? true : false;
            gb = PlayerPrefs.GetInt("gb") == 1 ? true : false;
            gw = PlayerPrefs.GetInt("gw") == 1 ? true : false;
            
            cbs = PlayerPrefs.GetInt("cbs");
            mbs = PlayerPrefs.GetInt("mbs");
            gbs = PlayerPrefs.GetInt("gbs");
            sr = PlayerPrefs.GetInt("sr");
            bn = PlayerPrefs.GetInt("bn");
        }
    }

    private void Update()
    {
        n++;
        if (n >= nSpawners) 
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

        if(ballSpawners[n].rarity == 0)
        {
            cCounter++;
            if (!ballSpawners[n].ballExist)
            {
                if(previouslyExists[n] != ballSpawners[n].ballExist)
                {
                    Debug.Log("Common Ball Scored");

                    if (commonsExists > nSpawners / 2)
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

                    if (commonsExists == nSpawners)
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

                    if (commonsExists == nSpawners)
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
