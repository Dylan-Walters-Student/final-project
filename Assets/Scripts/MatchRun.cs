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
    SceneLoader load;
    bool stopTimer;

    void Start() 
    {
        load = new SceneLoader();
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
        load.MainMenu();
    }
}
