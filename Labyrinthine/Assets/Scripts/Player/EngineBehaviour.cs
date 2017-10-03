using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBehaviour : MonoBehaviour
{
    public float engineHeatAmount { get; set; }
    [SerializeField]
    float heatIncreaseAmount = 1.0f;
    // Update is called once per frame

    void Start()
    {
        engineHeatAmount = 75.0f;
    }
    void FixedUpdate ()
    {
        engineHeatAmount += heatIncreaseAmount;
        //Debug.Log(engineHeatAmount);
        if(engineHeatAmount > 100.0f)
        {
            engineHeatAmount = 100.0f;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            engineHeatAmount -= 50;
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            engineHeatAmount += 50;
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
