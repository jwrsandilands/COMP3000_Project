using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ControllerSync : MonoBehaviour
{
    //controllers connected?
    public bool p1, p2; //players in?
    public Gamepad player1, player2; //player Controllers
    public bool playersSpawned;
    public GameObject car;
    public GameObject redCar, blueCar;
    public Material redSkin, blueSkin;
    public Vector3 spawnCoordsRed, spawnCoordsBlue;
    public Vector3 spawnRotRed, spawnRotBlue;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (player1 == null && Gamepad.current.leftShoulder.ReadValue() == 1 && Gamepad.current.rightShoulder.ReadValue() == 1)
        {
            player1 = Gamepad.current;
            p1 = true;
        }
        else if (player2 == null && Gamepad.current != player1 && Gamepad.current.leftShoulder.ReadValue() == 1 && Gamepad.current.rightShoulder.ReadValue() == 1)
        {
            player2 = Gamepad.current;
            p2 = true;
        }

        if(SceneManager.GetActiveScene().name != "GameMenu" && !playersSpawned)
        {
            playersSpawned = true;

            blueCar = Instantiate(car);
            blueCar.transform.GetChild(1).GetComponent<Renderer>().material = blueSkin;
            blueCar.transform.position = spawnCoordsBlue;
            blueCar.transform.Rotate(spawnRotBlue);
            blueCar.GetComponent<CarController>().player = player1;
            blueCar.GetComponent<CarController>().playerNumber = 1;

            redCar = Instantiate(car);
            redCar.transform.GetChild(1).GetComponent<Renderer>().material = redSkin;
            redCar.transform.position = spawnCoordsRed;
            redCar.transform.Rotate(spawnRotRed);
            redCar.GetComponent<CarController>().player = player2;
            redCar.GetComponent<CarController>().playerNumber = 2;
        }
    }
}
