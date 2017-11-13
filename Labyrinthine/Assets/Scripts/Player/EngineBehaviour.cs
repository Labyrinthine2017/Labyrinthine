using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBehaviour : MonoBehaviour
{
    public float engineHeatAmount { get; set; }
    [SerializeField] GameObject blast;
    [SerializeField]
    float heatIncreaseAmount = 1.0f;
    float timer = 0.0f;
    // Update is called once per frame

    void Start()
    {
        engineHeatAmount = 0.0f;
    }
    void FixedUpdate ()
    {
        //Every second your engine's heat increases.
        engineHeatAmount += heatIncreaseAmount;
        
        //Keeps the engineHeatAmount from going over 100 and shuts the engine down.
        if(engineHeatAmount > 100.0f)
        {
            engineHeatAmount = 100.0f;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            var emission = blast.GetComponent<ParticleSystem>().emission;
            if (emission.enabled == false)
            {
                emission.enabled = true;
            }
        }
        else
        {
            gameObject.GetComponent<PlayerMovement>().enabled = true;
        }
        if(engineHeatAmount < 0.0f)
        {
            engineHeatAmount = 0.0f;
        }
        //Commands for testing
        if(Debug.isDebugBuild)
        { 
        if(Input.GetKeyDown(KeyCode.C))
        {
            engineHeatAmount -= 50;
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            engineHeatAmount += 50;
        }
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
