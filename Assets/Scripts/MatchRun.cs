using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MatchRun : MonoBehaviour
{
    [SerializeField] Slider timerSlider;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float gameTime;
    SceneLoader loadScene;
    bool stopTimer;

    void Start() 
    {
        GameObject gameObject = new GameObject("SceneLoader");
        loadScene = gameObject.AddComponent<SceneLoader>(); //adds a new instance of a MonoBehaviour class

        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    void Update()
    {
        Timer();
    }

    void Timer()
    {
        float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (time <= 0)
        {
            stopTimer = false;
            ReturnToMainMenu();
        }

        if (stopTimer == false)
        {
            timerText.text = textTime;
            timerSlider.value = time;
        }
    }

    void ReturnToMainMenu()
    {
        loadScene.MainMenu();
    }
}
