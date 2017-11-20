using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityClamping : MonoBehaviour
{
	//11061
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(transform.TransformPoint(transform.localPosition).z);
		if(transform.TransformPoint(transform.localPosition).z >= 11061.0f)
        {
            transform.parent = null;
        }
        
	}
}
