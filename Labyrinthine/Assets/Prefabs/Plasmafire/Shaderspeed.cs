using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaderspeed : MonoBehaviour
{

	Renderer rend;
	float material1 = 0.0000001f;
    float material2 = 9.000009f;
    public float increaseAmount;
    float material1Amount;
    float material2Amount;
	// Use this for initialization
	void Start ()
	{
		rend = this.GetComponent<Renderer>();
        material1Amount = increaseAmount;
        material2Amount = -increaseAmount;
	}

	// Update is called once per frame
	void Update ()
	{
		if(material1 >= 10.0f)
		{
            material1Amount = -1* material1Amount;
		}
		if(material1 <= 0.0f)
		{
            material1Amount = -1 * material1Amount;
		}
        material1 += material1Amount;
		rend.material.SetFloat("_texturemove", material1);


        if (material2 >= 10.0f)
        {
            material2Amount = -1 * material2Amount;
        }
        if (material2 <= 0.0f)
        {
            material2Amount = -1 * material2Amount;
        }
        material2 += material2Amount;
        rend.material.SetFloat("_texturemove", material2);


    }
}
