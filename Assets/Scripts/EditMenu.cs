using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI steerText;
    [SerializeField] TextMeshProUGUI basePointText;
    [SerializeField]int speedCost = 10;
    [SerializeField]int steerCost = 15;
    [SerializeField]int basePoint = 20;
    PlayerMovement playerMovement;
    Scoring score;
    int speedLevel;
    int steerLevel;
    int basePointLevel;
    [SerializeField]int points;
    int levelmax = 7;

    void Start()
    {
        playerMovement = new PlayerMovement();
        score = new Scoring();
        points += score.GetScoretoPoints();
        SetMainMenuPoint();
        StartNumber();
    }

    private void SetMainMenuPoint()
    {
        points = score.GetScoretoPoints();
        pointText.text = $"Points: {points}";
    }

    private void StartNumber()
    {
        pointText.text = $"{points}";
        speedText.text = $"Speed Cost: {speedCost}";
        steerText.text = $"Steer Cost: {steerCost}";
        basePointText.text = $"Point Increase Cost: {basePoint}";
    }

    public void UpgradeSpeed()
    {
        if (points > speedCost && speedLevel < levelmax)
        {
            points -= speedCost;
            pointText.text = $"Points: {points}";
            playerMovement.SetSpeed(2);
            speedCost = (int)(speedCost * 1.5);
            speedLevel++;
            speedText.text = $"Speed Cost: {speedCost}";
        }
        else if (speedLevel == levelmax)
        {
            speedText.text = $"Speed: MAX LEVEL";
        }
    }

    public void UpgradeSteer()
    {
        if (points > steerCost && steerLevel < levelmax)
        {
            points -= steerCost;
            pointText.text = $"Points: {points}";
            playerMovement.SetSteerSpeed(10);
            steerCost = (int)(steerCost * 1.5);
            steerLevel++;
            steerText.text = $"Steer Cost: {steerCost}";
        }
        else if (steerLevel == levelmax)
        {
            speedText.text = $"Steer: MAX LEVEL";
        }
    }


    public void UpgradeBasePoint()
    {
        if (points > basePoint && basePointLevel < levelmax)
        {
            points -= basePoint;
            pointText.text = $"Points: {points}";
            score.SetBaseScoreing(2);
            basePoint = (int)(basePoint * 1.5);
            basePointLevel++;
            basePointText.text = $"Point Increase Cost: {basePoint}";
        }
        else if (steerLevel == levelmax)
        {
            speedText.text = $"Points: MAX LEVEL";
        }
    }
}
