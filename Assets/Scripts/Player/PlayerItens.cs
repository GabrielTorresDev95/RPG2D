using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    public int totalWood;

    public int currentWater;
    private int waterLimit = 50;

    public void WaterLimit(int water)
    {
        if(currentWater <= waterLimit)
        {
            currentWater += water;
        }
    }
}
