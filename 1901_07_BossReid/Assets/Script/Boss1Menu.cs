using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1Menu : MonoBehaviour
{
    public GameObject LoseObject;

    public void Exit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        // go.SetActive(false);
        Time.timeScale = 1;
    }

    public void ClickMain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
