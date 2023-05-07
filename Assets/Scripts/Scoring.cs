using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField] GameObject bumperRed;
    [SerializeField] GameObject bumperBlue;
    Collection collection;
    bool alliance;  // true is blue alliance, false is red
    int allianceScore;
    bool hasPiece;
    int scoreBase = 2;
    int high = 3;
    int mid = 2;

    void Start()
    {
        collection = FindObjectOfType<Collection>();
        AlliancePick();
        allianceScore = 0;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (alliance)
        {
            if (other.tag == "HighZoneBlue" || other.tag == "MidZoneBlue" || other.tag == "LowZoneBlue")
            {
                ScoreGrid(other);
            }
        }
        else
        {
            if (other.tag == "HighZoneRed" || other.tag == "MidZoneRed" || other.tag == "LowZoneRed")
            {
                ScoreGrid(other);
            }
        }
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

    private void AddScore(int zone)
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
        collection.SetGamePieceShow(3);
        Debug.Log(allianceScore);
    }

    private void ScoreGrid(Collider2D other)
    {
        if (other.tag == "HighZoneRed" || other.tag == "HighZoneBlue" && hasPiece)
        {
            AddScore(1);
        }

        if (other.tag == "MidZoneRed" || other.tag == "MidZoneBlue" && hasPiece)
        {
            AddScore(2);
        }

        if (other.tag == "LowZoneRed" || other.tag == "LowZoneBlue" && hasPiece)
        {
            AddScore(3);

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
}
