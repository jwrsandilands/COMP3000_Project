using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsRetriever : MonoBehaviour
{
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
        Debug.Log(PlayerPrefs.GetInt("gw") == 1 ? true : false);

        Debug.Log(PlayerPrefs.GetInt("sr"));
        Debug.Log(PlayerPrefs.GetInt("bn"));

    }
}
