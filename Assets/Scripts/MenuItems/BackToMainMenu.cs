using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        Button bkBtn = backBtn.GetComponent<Button>();
        bkBtn.onClick.AddListener(SceneChange);
    }

    void SceneChange()
    {
        Destroy(GameObject.FindGameObjectWithTag("ControllerSystem")); //destroy old controller system

        SceneManager.LoadScene("GameMenu"); //go back to the main menu
        Time.timeScale = 1; //unpause time
    }
}
