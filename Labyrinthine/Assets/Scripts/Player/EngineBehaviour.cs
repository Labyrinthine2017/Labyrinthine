using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBehaviour : MonoBehaviour
{
    float engineHeatAmount { get; set; }
    [SerializeField]
    float heatIncreaseAmount = 0.0005f;
	// Update is called once per frame
	void FixedUpdate ()
    {
        engineHeatAmount += heatIncreaseAmount;
        //Debug.Log(engineHeatAmount);
        if(engineHeatAmount > 100.0f)
        {
            engineHeatAmount = 100.0f;
        }
	}

    public void CoolEngineByAmount(float a_amount)
    {
        engineHeatAmount -= a_amount;
        //Check to prevent the heat gauge going below 0
        if(engineHeatAmount < 0.0f)
        {
            engineHeatAmount = 0.0f;
        }
    }
}
