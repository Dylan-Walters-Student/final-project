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
    bool hasCone;
    bool hasCube;
    int cube = 2;
    int cone = 3;
    int high = 3;
    int mid = 3;

    void Start()
    {
        collection = FindObjectOfType<Collection>();
        AlliancePick();
        allianceScore = 0;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PieceStatus(collection.GetCollected());
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

    private void AddScore(string zone)
    {
        if (zone.Equals("High"))
        {
            if (hasCone)
            {
                allianceScore += cone + high;
            }

            if (hasCube)
            {
                allianceScore += cube + high;
            }
        }

        if (zone.Equals("Mid"))
        {
            if (hasCone)
            {
                allianceScore += cone + mid;
            }

            if (hasCube)
            {
                allianceScore += cube + mid;
            }
        }

        if (zone.Equals("Low"))
        {
            if (hasCone)
            {
                allianceScore += cone;
            }

            if (hasCube)
            {
                allianceScore += cube;
            }
        }
        collection.SetGamePieceShow(3);
        Debug.Log(allianceScore);
    }

    private void ScoreGrid(Collider2D other)
    {
        if (other.tag.Equals("HighZoneRed") && hasCone || hasCube)
        {
            AddScore("High");
        }

        if (other.tag.Equals("MidZoneRed") && hasCone || hasCube)
        {
            AddScore("Mid");

        }

        if (other.tag.Equals("LowZoneRed") && hasCone || hasCube)
        {
            AddScore("Low");

        }

        if (other.tag.Equals("HighZoneBlue") && hasCone || hasCube)
        {
            AddScore("High");
        }

        if (other.tag.Equals("MidZoneBlue") && hasCone || hasCube)
        {
            AddScore("Mid");
        }

        if (other.tag.Equals("LowZoneBlue") && hasCone || hasCube)
        {
            AddScore("Low");

        }
    }

    public void PieceStatus(int status)
    {
        if (status == 1)
        {
            hasCone = true;
        }
        else if (status == 2)
        {
            hasCube = true;
        }
        else
        {
            hasCone = false;
            hasCube = false;
        }
    }

    public bool GetAlliance()
    {
        return alliance;
    }
}
