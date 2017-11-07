using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    EngineBehaviour engine;
    Renderer rend;
    
    float value =  0.0f;
	// Use this for initialization
	void Start ()
    {
        engine = GameObject.FindGameObjectWithTag("Player").GetComponent<EngineBehaviour>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //1 / 100 = 0.x
        //0.x * 3 = value required
        value = (1 / engine.engineHeatAmount) * 3;
        rend.material.SetFloat("node_3604", value);

	}
}
