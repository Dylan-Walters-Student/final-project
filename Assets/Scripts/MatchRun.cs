using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRun : MonoBehaviour
{
    [SerializeField] float gameTime = 250f;
    bool gameRunning;
    float timerValue;
    float fillFraction;
    float timeLeft;
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        timerValue -= Time.deltaTime;

        if (gameRunning)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeLeft;
            }
            else
            {
                gameRunning = false;
                // run a pop up screen / return to main menu
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / gameTime;
            }
            else
            {
                gameRunning = true;
                timerValue = gameTime;
            }
        }
    }
}
