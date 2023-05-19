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
    [SerializeField] SpriteRenderer speedBattery; // 0
    [SerializeField] SpriteRenderer steerBattery; // 1
    [SerializeField] SpriteRenderer pointBattery; // 2
    [SerializeField] Sprite battery0;
    [SerializeField] Sprite battery1;
    [SerializeField] Sprite battery2;
    [SerializeField] Sprite battery3;
    [SerializeField] Sprite battery4;
    [SerializeField] Sprite battery5;
    [SerializeField] Sprite battery6;
    [SerializeField] int points;
    PlayerMovement playerMovement;
    Scoring score;
    int levelmax = 7;

    void Start()
    {
        playerMovement = new PlayerMovement();
        score = new Scoring();
        points = StaticHelper.points;
        pointText.text = $"Points: {points}";
        StartNumber();
        BatterySwitch(StaticHelper.speedLevel, 0);
        BatterySwitch(StaticHelper.steerLevel, 1);
        BatterySwitch(StaticHelper.basePointLevel, 2);
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
        if (points > StaticHelper.speedCost && StaticHelper.speedLevel < levelmax)
        {
            points -= StaticHelper.speedCost;
            pointText.text = $"Points: {points}";
            playerMovement.SetSpeed(5);
            StaticHelper.speedCost = (int)(StaticHelper.speedCost * 1.5);
            StaticHelper.speedLevel++;
            speedText.text = $"Speed Cost: {StaticHelper.speedCost}";
            BatterySwitch(StaticHelper.speedLevel, 0);
        }
    }

    public void UpgradeSteer()
    {
        if (points > StaticHelper.steerCost && StaticHelper.steerLevel < levelmax)
        {
            points -= StaticHelper.steerCost;
            pointText.text = $"Points: {points}";
            playerMovement.SetSteerSpeed(15);
            StaticHelper.steerCost = (int)(StaticHelper.steerCost * 1.5);
            StaticHelper.steerLevel++;
            steerText.text = $"Steer Cost: {StaticHelper.steerCost}";
            BatterySwitch(StaticHelper.steerLevel, 1);
        }
    }


    public void UpgradeBasePoint()
    {
        if (points > StaticHelper.basePoint && StaticHelper.basePointLevel < levelmax)
        {
            points -= StaticHelper.basePoint;
            pointText.text = $"Points: {points}";
            StaticHelper.scorebase += 1;
            StaticHelper.basePoint = (int)(StaticHelper.basePoint * 1.5);
            StaticHelper.basePointLevel++;
            basePointText.text = $"Score Increase Cost: {StaticHelper.basePoint}";
            BatterySwitch(StaticHelper.basePointLevel, 2);
        }
    }

    private void BatterySwitch(int level, int batteryTypeStatus)
    {
        switch (level)
        {
            case 1:
                if (batteryTypeStatus == 0)
                {
                    speedBattery.sprite = battery0;
                }

                if (batteryTypeStatus == 1)
                {
                    steerBattery.sprite = battery0;
                }

                if (batteryTypeStatus == 2)
                {
                    pointBattery.sprite = battery0;
                }
                break;
            case 2:
                if (batteryTypeStatus == 0)
                {
                    speedBattery.sprite = battery1;
                }

                if (batteryTypeStatus == 1)
                {
                    steerBattery.sprite = battery1;
                }

                if (batteryTypeStatus == 2)
                {
                    pointBattery.sprite = battery1;
                }
                break;
            case 3:
                if (batteryTypeStatus == 0)
                {
                    speedBattery.sprite = battery2;
                }

                if (batteryTypeStatus == 1)
                {
                    steerBattery.sprite = battery2;
                }

                if (batteryTypeStatus == 2)
                {
                    pointBattery.sprite = battery2;
                }
                break;
            case 4:
                if (batteryTypeStatus == 0)
                {
                    speedBattery.sprite = battery3;
                }

                if (batteryTypeStatus == 1)
                {
                    steerBattery.sprite = battery3;
                }

                if (batteryTypeStatus == 2)
                {
                    pointBattery.sprite = battery3;
                }
                break;
            case 5:
                if (batteryTypeStatus == 0)
                {
                    speedBattery.sprite = battery4;
                }

                if (batteryTypeStatus == 1)
                {
                    steerBattery.sprite = battery4;
                }

                if (batteryTypeStatus == 2)
                {
                    pointBattery.sprite = battery4;
                }
                break;
            case 6:
                if (batteryTypeStatus == 0)
                {
                    speedBattery.sprite = battery5;
                }

                if (batteryTypeStatus == 1)
                {
                    steerBattery.sprite = battery5;
                }

                if (batteryTypeStatus == 2)
                {
                    pointBattery.sprite = battery5;
                }
                break;
            case 7:
                if (batteryTypeStatus == 0)
                {
                    speedBattery.sprite = battery6;
                    speedText.text = $"Speed: MAX LEVEL";
                }

                if (batteryTypeStatus == 1)
                {
                    steerBattery.sprite = battery6;
                    steerText.text = $"Steer: MAX LEVEL";
                }

                if (batteryTypeStatus == 2)
                {
                    pointBattery.sprite = battery6;
                    basePointText.text = $"Score Increase: MAX LEVEL";
                }
                break;
            default:
                if (batteryTypeStatus == 0)
                {
                    speedBattery.sprite = battery0;
                }

                if (batteryTypeStatus == 1)
                {
                    steerBattery.sprite = battery0;
                }

                if (batteryTypeStatus == 2)
                {
                    pointBattery.sprite = battery0;
                }
                break;
        }
    }
}
