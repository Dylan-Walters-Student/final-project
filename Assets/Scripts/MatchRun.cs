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
    AudioSource FinishMatchSound;
    bool stopTimer;
    void Start()
    {
        loadScene = FindObjectOfType<SceneLoader>();

        FinishMatchSound = GetComponent<AudioSource>();

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
            // score.GivePlayerPoints();  place it somewhere else
            FinishMatchSound.Play();
            loadScene.MainMenu();
        }
    }
}
