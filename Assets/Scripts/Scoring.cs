using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI redScore;
    [SerializeField] TextMeshProUGUI blueScore;
    [SerializeField] GameObject bumperRed;
    [SerializeField] GameObject bumperBlue;
    Collection collection;
    bool alliance;  // true is blue alliance, false is red
    int allianceScore;
    bool hasPiece;
    int scoreBase = 2;
    int high = 4;
    int mid = 3;

    void Start()
    {
        redScore = FindObjectOfType<TextMeshProUGUI>();
        blueScore = FindObjectOfType<TextMeshProUGUI>();
        collection = FindObjectOfType<Collection>();
        AlliancePick();
        allianceScore = 0;
        ShowScore();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Score(other);
        ShowScore();
    }

    private void AlliancePick()
    {
        if (Random.value >= 0.5)
        {
            alliance = true;
        }

        if (alliance)
        {
            bumperBlue.SetActive(true);
            bumperRed.SetActive(false);
        }
        else
        {
            bumperRed.SetActive(true);
            bumperBlue.SetActive(false);
        }

    }

    private void Score(Collider2D other)
    {
        if (alliance)
        {
            if (other.tag == "HighZoneBlue" || other.tag == "MidZoneBlue" || other.tag == "LowZoneBlue")
            {
                ZoneCheck(other);
            }
        }
        else
        {
            if (other.tag == "HighZoneRed" || other.tag == "MidZoneRed" || other.tag == "LowZoneRed")
            {
                ZoneCheck(other);
            }
        }
    }

    private void ZoneCheck(Collider2D other)
    {
        if (other.tag == "HighZoneRed" && hasPiece || other.tag == "HighZoneBlue" && hasPiece)
        {
            AddPoints(1);
        }

        if (other.tag == "MidZoneRed" && hasPiece || other.tag == "MidZoneBlue" && hasPiece)
        {
            AddPoints(2);
        }

        if (other.tag == "LowZoneRed" && hasPiece || other.tag == "LowZoneBlue" && hasPiece)
        {
            AddPoints(3);

        }
    }

    private void AddPoints(int zone)
    {
        if (zone == 1)
        {
            allianceScore += scoreBase + high;
        }

        if (zone == 2)
        {
            allianceScore += scoreBase + mid;
        }

        if (zone == 3)
        {
            allianceScore += scoreBase;
        }
        collection.AddGamePiece(3);
        Debug.Log(allianceScore);
    }

    private void ShowScore()
    {
        if (alliance)
        {
            blueScore.text = $"{allianceScore}";
        }
        else
        {
            redScore.text = $"{allianceScore}";
        }
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

    public bool GetAlliance()
    {
        return alliance;
    }

    public int GetScoretoPoints()
    {
        int points;
        points = (int)(allianceScore * 0.15);
        return points;
    }

    public void SetBaseScoreing(int increaseAmount)
    {
        scoreBase += increaseAmount;
    }
}
