using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject go;

    private bool activated;

    public void Exit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        activated = false;
        go.SetActive(false);
        Time.timeScale = 1;
    }

    public void ClickMain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            activated = !activated;

            if(activated)
            {
                go.SetActive(true);
                Time.timeScale = 0;
            }

            else
            {
                go.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
