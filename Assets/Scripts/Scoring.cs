using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField] GameObject bumperRed;
    [SerializeField] GameObject bumperBlue;
    Collection collection;
    int cube = 2;
    int cone = 3;
    int high = 3;
    int mid = 3;
    bool alliance;  // true is blue alliance, false is red
    int allianceScore;
    bool hasCone;
    bool hasCube;

    void Start()
    {
        collection = FindObjectOfType<Collection>();
        AlliancePick();
        allianceScore = 0;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckZone(other))
        {
            ScoreGrid(other);
            Debug.Log(hasCone + " cone");
            Debug.Log(hasCube + " cube");
            Debug.Log(allianceScore + " Score");
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
            if (hasCone)
            {
                allianceScore += cone + high;
            }
            else
            {
                allianceScore += cube + high;
            }
            Debug.Log("High");
        }
        else if (zone == "Mid")
        {
            if (hasCone)
            {
                allianceScore += cone + mid;
            }
            else
            {
                allianceScore += cube + mid;
            }
            Debug.Log("Mid");
        }
        else if (zone == "Low")
        {
            if (hasCone)
            {
                allianceScore += cone;
            }
            else
            {
                allianceScore += cube;
            }
            Debug.Log("Low");
        }
    }

    private void ScoreGrid(Collider2D other)
    {
        if (other.tag == "HighZoneRed" && hasCone || hasCube && !alliance)
        {
            AddScore("High");
            Debug.Log("HighRed");
        }

        if (other.tag == "MidZoneRed" && hasCone || hasCube && !alliance)
        {
            AddScore("Mid");
            Debug.Log("MidRed");
        }

        if (other.tag == "LowZoneRed" && hasCone || hasCube && !alliance)
        {
            AddScore("Low");
            Debug.Log("LowRed");
        }

        if (other.tag == "HighZoneBlue" && hasCone || hasCube && alliance)
        {
            AddScore("High");
            Debug.Log("HighBlue");
        }

        if (other.tag == "MidZoneBlue" && hasCone || hasCube && alliance)
        {
            AddScore("Mid");
            Debug.Log("MidBlue");
        }

        if (other.tag == "LowZoneBlue" && hasCone || hasCube && alliance)
        {
            AddScore("Low");
            Debug.Log("LowBlue");
        }

        collection.SetGamePieceShow("None");
    }

    private bool CheckZone(Collider2D other)
    {
        return other.tag == "HighZoneRed" || other.tag == "HighZoneBlue" || 
            other.tag == "MidZoneRed" || other.tag == "MidZoneBlue" || 
            other.tag == "LowZoneRed" || other.tag == "LowZoneBlue";
    }

}
