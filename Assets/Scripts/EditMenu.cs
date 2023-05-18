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
        points = StaticHelper.points;
        pointText.text = $"Points: {points}";
        StartNumber();
    }

    private void StartNumber()
    {
        pointText.text = $"{points}";
        speedText.text = $"Speed Cost: {StaticHelper.speedCost}";
        steerText.text = $"Steer Cost: {StaticHelper.steerCost}";
        basePointText.text = $"Point Increase Cost: {StaticHelper.basePoint}";
    }

    public void UpgradeSpeed()
    {
        if (points > StaticHelper.speedCost && speedLevel < levelmax)
        {
            points -= StaticHelper.speedCost;
            pointText.text = $"Points: {points}";
            playerMovement.SetSpeed(2);
            StaticHelper.speedCost = (int)(StaticHelper.speedCost * 1.5);
            speedLevel++;
            speedText.text = $"Speed Cost: {StaticHelper.speedCost}";
        }
        else if (speedLevel == levelmax)
        {
            speedText.text = $"Speed: MAX LEVEL";
        }
    }

    public void UpgradeSteer()
    {
        if (points > StaticHelper.steerCost && steerLevel < levelmax)
        {
            points -= StaticHelper.steerCost;
            pointText.text = $"Points: {points}";
            playerMovement.SetSteerSpeed(10);
            StaticHelper.steerCost = (int)(StaticHelper.steerCost * 1.5);
            steerLevel++;
            steerText.text = $"Steer Cost: {StaticHelper.steerCost}";
        }
        else if (steerLevel == levelmax)
        {
            steerText.text = $"Steer: MAX LEVEL";
        }
    }


    public void UpgradeBasePoint()
    {
        if (points > StaticHelper.basePoint && basePointLevel < levelmax)
        {
            points -= StaticHelper.basePoint;
            pointText.text = $"Points: {points}";
            StaticHelper.scorebase += 1;
            StaticHelper.basePoint = (int)(StaticHelper.basePoint * 1.5);
            basePointLevel++;
            basePointText.text = $"Score Increase Cost: {StaticHelper.basePoint}";
        }
        else if (steerLevel == levelmax)
        {
            basePointText.text = $"Score Increase: MAX LEVEL";
        }
    }
}
