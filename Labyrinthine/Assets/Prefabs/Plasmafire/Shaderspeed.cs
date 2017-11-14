using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaderspeed : MonoBehaviour {

	Renderer rend;
	float value = 0.0000001f;
	public float increaseAmount;
	// Use this for initialization
	void Start ()
	{
		rend = this.GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update ()
	{
		if(value >= 10.0f)
		{
			increaseAmount = -1*increaseAmount;
		}
		if(value <= 0.0f)
		{
			increaseAmount = -1 * increaseAmount;
		}
		value += increaseAmount;

		rend.material.SetFloat("_texturemove", value);
	}
}
