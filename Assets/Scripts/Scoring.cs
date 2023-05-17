using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI blueScoreText;
    [SerializeField] GameObject bumperBlue;
    Collection collection;
    int blueScore;
    bool hasPiece;
    int high = 4;
    int mid = 3;
    int scoreBase = 2;

    void Start()
    {
        blueScoreText = FindObjectOfType<TextMeshProUGUI>();
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
        if (other.tag == "HighZoneBlue" && hasPiece)
        {
            blueScore += scoreBase + high;
        }

        if (other.tag == "MidZoneBlue" && hasPiece)
        {
            blueScore += scoreBase + mid;
        }

        if (other.tag == "LowZoneBlue" && hasPiece)
        {
            blueScore += scoreBase;
        }
        collection.RemoveGamePiece();
    }

    private void ShowScore()
    {
        blueScoreText.text = $"{blueScore}";
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
        StaticHelper.points += (int)(blueScore * 0.30);
    }

    public void SetBaseScoreing(int increaseAmount)
    {
        scoreBase += increaseAmount;
    }
}