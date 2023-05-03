using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    int scoreHighCone = 6;
    int scoreHighCube = 5;
    int scoreMidCone = 5;
    int scoreMidCube = 4;
    int scoreLowCone = 3;
    int scoreLowCube = 2;
    bool alliance;  // true is blue alliance, false is red
    int allianceScore;
    bool hasCone;
    bool hasCube;


    void Start() {
        AlliancePick();
        allianceScore = 0;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "HighZoneRed" && hasCone || hasCube && !alliance)
        {
            AddScore("High");
        }

        if (other.tag == "MidZoneRed" && hasCone || hasCube && !alliance)
        {
            AddScore("Mid");
        }

        if (other.tag == "LowZoneRed" && hasCone || hasCube && !alliance)
        {
            AddScore("Low");
        }

        if (other.tag == "HighZoneBlue" && hasCone || hasCube && alliance)
        {
            AddScore("High");
        }

        if (other.tag == "MidZoneBlue" && hasCone || hasCube && alliance)
        {
            AddScore("Mid");
        }

        if (other.tag == "LowZoneBlue" && hasCone || hasCube && alliance)
        {
            AddScore("Low");
        }
    }

    private void AlliancePick()
    {
        if (Random.value >= 0.5)
        {
            alliance = true;
        }
    }

    private void AddScore (string scoreType)
    {
        if (scoreType == "High")
        {
            if (hasCone)
            {
                allianceScore += scoreHighCone;
            }
            else
            {
                allianceScore += scoreHighCube;
            }
        }
        else if (scoreType == "Mid")
        {
            if (hasCone)
            {
                allianceScore += scoreMidCone;
            }
            else
            {
                allianceScore += scoreMidCube;
            }
        }
        else if (scoreType == "Low")
        {
            if (hasCone)
            {
                allianceScore += scoreLowCone;
            }
            else
            {
                allianceScore += scoreLowCube;
            }
        }
    }
}
