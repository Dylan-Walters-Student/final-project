using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticHelper 
{
    //allows for use across multiple scripts/ no need for instance
    public static bool stopTimer = true;
    public static int points;
    public static float time;
    public static bool hasPiece;

    public static int speedCost = 10;
    public static int steerCost = 15;
    public static int basePoint = 20;
    
    public static int scorebase = 2;
}
