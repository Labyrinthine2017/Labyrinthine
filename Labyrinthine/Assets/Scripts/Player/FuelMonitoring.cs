using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelMonitoring : MonoBehaviour
{
    public float totalFuelAmount { get; set; }
    float timer;
    public float secondsToWait;
    public float fuelToDegradeWith;
    void Start()
    {
        totalFuelAmount = 100.0f;
    }
    void Update()
    {
        Debug.Log(totalFuelAmount);
        timer += Time.deltaTime;
        if(timer > secondsToWait)
        {
            totalFuelAmount -= fuelToDegradeWith;
            timer = 0.0f;
        }
    }
    public void AlterFuelAmount(float amountOfFuelToAlterWith)
    {
        
        totalFuelAmount += amountOfFuelToAlterWith;
        //Prevents the fuel amount going over 100
        if(totalFuelAmount > 100.0f)
        {
            totalFuelAmount = 100.0f;
        }
    }
}
