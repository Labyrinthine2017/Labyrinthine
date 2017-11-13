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
        rend = this.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        value = 3 * 1 * (engine.engineHeatAmount / 100);
        rend.material.SetFloat("_node_3604", value);
        //Debug.Log(rend.material.GetFloat("_node_3604"));
	}
}
