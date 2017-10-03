using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedleMovement : MonoBehaviour
{
    EngineBehaviour playerEngine;
    float rotationAmount;

	// Use this for initialization
	void Awake ()
    {
        playerEngine = GameObject.FindGameObjectWithTag("Player").GetComponent<EngineBehaviour>();
        rotationAmount = 1.8f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(new Vector3(0.0f, 0.0f, (playerEngine.engineHeatAmount * rotationAmount) + 270)));
    }
}
