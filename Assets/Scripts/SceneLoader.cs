using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{ 
    public void StartGame()
    {
        StaticHelper.stopTimer = false;
        StaticHelper.time = 60;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void EditMenu()
    {
        SceneManager.LoadScene(2);
    }
}
