using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    public int scoreP1, scoreP2;
    public Text textP1, textP2;

    // Update is called once per frame
    void Update()
    {
        textP1.text = "Score P1: " + scoreP1;
        textP2.text = "Score P2: " + scoreP2;
    }
}

