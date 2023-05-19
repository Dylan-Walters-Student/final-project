using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScrene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI RedScore;
    [SerializeField] TextMeshProUGUI BlueScore;
    [SerializeField] TextMeshProUGUI WinningAlliance;
    private void Start() 
    {
        Winner();
    }

    private void Winner()
    {
        if(StaticHelper.finalEnemyScore > StaticHelper.finalPlayerScore)
        {
            WinningAlliance.text = "Red Wins!";
        }
        else if (StaticHelper.finalEnemyScore == StaticHelper.finalPlayerScore)
        {
            WinningAlliance.text = "Tie Game!";
        }
        else
        {
            WinningAlliance.text = "Blue Wins!";
        }

        RedScore.text = $"{StaticHelper.finalEnemyScore}";
        BlueScore.text = $"{StaticHelper.finalPlayerScore}";
    }
}
