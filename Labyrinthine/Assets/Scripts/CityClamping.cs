//=======================================================
//  File Author:     Brent Kingma 
//
//  File Name:       CityClamping
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityClamping : MonoBehaviour
{
	// During update, sets the parent to null and clamps the city
	void Update ()
    {
        Debug.Log(transform.TransformPoint(transform.localPosition).z);
		if(transform.TransformPoint(transform.localPosition).z >= 11061.0f)
        {
            transform.parent = null;
        }
        
	}
}
