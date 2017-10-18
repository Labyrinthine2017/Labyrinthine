using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    bool crossed;
	// Use this for initialization
	void Start ()
    {
	   	if(transform.rotation.y > 0.0f)
        {
            crossed = false;
        }
        else if(transform.rotation.y < 0.0f)
        {
            crossed = true;
        }
	}

    public bool GetState()
    {
        return crossed;
    }
}
