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
        }
    }

    private void ScoreGrid(Collider2D other)
    {
        Debug.Log (other.tag + " tag");
        if (other.tag == "HighZoneRed" && hasCone || hasCube /*&& !alliance*/)
        {
            AddScore("High");
        }

        if (other.tag == "MidZoneRed" && hasCone || hasCube /*&& !alliance*/)
        {
            AddScore("Mid");
        }

        if (other.tag == "LowZoneRed" && hasCone || hasCube /*&& !alliance*/)
        {
            AddScore("Low");
        }

        if (other.tag == "HighZoneBlue" && hasCone || hasCube /*&& alliance*/)
        {
            AddScore("High");
        }

        if (other.tag == "MidZoneBlue" && hasCone || hasCube /*&& alliance*/)
        {
            AddScore("Mid");
        }

        if (other.tag == "LowZoneBlue" && hasCone || hasCube /*&& alliance*/)
        {
            AddScore("Low");
        }

        collection.SetGamePieceShow("None");
        Debug.Log(allianceScore);
    }

    private bool CheckZone(Collider2D other)
    {
        return other.tag == "HighZoneRed" || other.tag == "HighZoneBlue" || 
            other.tag == "MidZoneRed" || other.tag == "MidZoneBlue" || 
            other.tag == "LowZoneRed" || other.tag == "LowZoneBlue";
    }

}
