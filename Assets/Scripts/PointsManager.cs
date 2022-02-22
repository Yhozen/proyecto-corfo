using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private int currentPoints = 0;
    public int pointsPerCoin = 25;


    public void onGetCoin()
    {
        currentPoints += pointsPerCoin;
    }
    public int getCurrentPoints()
    {
        return currentPoints;
    }
}
