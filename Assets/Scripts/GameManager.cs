using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int points;

    public void AddPoints(int amount)
    {
        points += amount;
    }

    public void SpendPoints(int amount)
    {
        points -= amount;
    }

    public int GetPointsTotal()
    {
        return points;
    }
}