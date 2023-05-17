using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI blueScoreTect;
    [SerializeField] GameObject bumperBlue;
    Collection collection;
    int blueScore;
    bool hasPiece;
    int high = 4;
    int mid = 3;
    int scoreBase = 2;

    void Start()
    {
        blueScoreTect = FindObjectOfType<TextMeshProUGUI>();
        collection = FindObjectOfType<Collection>();
        blueScore = 0;
        ShowScore();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Score(other);
        ShowScore();
    }

    private void Score(Collider2D other)
    {
        if (other.tag == "HighZoneBlue" || other.tag == "MidZoneBlue" || other.tag == "LowZoneBlue")
        {
            ZoneCheck(other);
        }
    }

    private void ZoneCheck(Collider2D other)
    {
        if (other.tag == "HighZoneBlue" && hasPiece)
        {
            AddPoints(1);
        }

        if (other.tag == "MidZoneBlue" && hasPiece)
        {
            AddPoints(2);
        }

        if (other.tag == "LowZoneBlue" && hasPiece)
        {
            AddPoints(3);
        }
    }

    private void AddPoints(int zone)
    {
        if (zone == 1)
        {
            blueScore += scoreBase + high;
        }

        if (zone == 2)
        {
            blueScore += scoreBase + mid;
        }

        if (zone == 3)
        {
            blueScore += scoreBase;
        }
        collection.AddGamePiece(3);
        Debug.Log(blueScore);
    }

    private void ShowScore()
    {
        blueScoreTect.text = $"{blueScore}";
    }

    public void SetPieceStatus(bool gamePieceStatus)
    {
        if (gamePieceStatus)
        {
            hasPiece = true;
        }
        else
        {
            hasPiece = false;
        }
    }
    public void GivePlayerPoints()
    {
        StaticHelper.points += (int)(blueScore * 0.15);
        Debug.Log(blueScore);
    }

    public void SetBaseScoreing(int increaseAmount)
    {
        scoreBase += increaseAmount;
    }
}