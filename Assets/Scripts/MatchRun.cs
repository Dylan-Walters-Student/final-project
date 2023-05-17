using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MatchRun : MonoBehaviour
{
    [SerializeField] Slider timerSlider;
    [SerializeField] TextMeshProUGUI timerText;
    SceneLoader loadScene;
    Scoring score;
    bool stopTimer;
    void Start()
    {
        GameObject gameObject = new GameObject("SceneLoader");
        loadScene = gameObject.AddComponent<SceneLoader>(); //adds a new instance of a MonoBehaviour class

        GameObject gameObject1 = new GameObject("Scoring");
        score = gameObject1.AddComponent<Scoring>();

        timerSlider.maxValue = StaticHelper.time;
        timerSlider.value = StaticHelper.time;
    }

    void Update()
    {
        if (!stopTimer)
        {
            Timer();
        }
    }

    void Timer()
    {
        float time = StaticHelper.time;
        if (stopTimer == false)
        {
            string textTime = "00:00";
            
            time = time - Time.timeSinceLevelLoad;

            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            textTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            timerText.text = textTime;
            timerSlider.value = time;
        }

        if (time <= 0)
        {
            stopTimer = true;
            score.GivePlayerPoints();
            loadScene.MainMenu();
        }
    }
}
