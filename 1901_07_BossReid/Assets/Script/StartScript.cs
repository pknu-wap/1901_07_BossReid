using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene(1);
    }

    public void isExit()
    {
        Application.Quit();
    }

    public void Boss3()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
