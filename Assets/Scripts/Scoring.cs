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
        if (zone == "High")
        {
            Debug.Log("High Zone");
            if (hasCone)
            {
                allianceScore += cone + high;
            }
            else
            {
                allianceScore += cube + high;
            }
        }

        if (zone == "Mid")
        {
            Debug.Log("Mid Zone");
            if (hasCone)
            {
                allianceScore += cone + mid;
            }
            else
            {
                allianceScore += cube + mid;
            }
        }

        if (zone == "Low")
        {
            Debug.Log("low Zone");
            if (hasCone)
            {
                allianceScore += cone;
            }
            else
            {
                allianceScore += cube;
            }
        }
        collection.SetGamePieceShow("None");
        Debug.Log(allianceScore);
    }

    private void ScoreGrid(Collider2D other)
    {
        if (other.tag.Equals("HighZoneRed")) // && hasCone || hasCube && !alliance
        {
            AddScore("High");
        }

        if (other.tag.Equals("MidZoneRed"))
        {
            AddScore("Mid");
        }

        if (other.tag.Equals("LowZoneRed"))
        {
            AddScore("Low");
        }

        if (other.tag.Equals("HighZoneBlue"))
        {
            AddScore("High");
        }

        if (other.tag.Equals("MidZoneBlue"))
        {
            AddScore("Mid");
        }

        if (other.tag.Equals("LowZoneBlue"))
        {
            AddScore("Low");
        }
    }

}
