using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProperties : MonoBehaviour
{	
	// Update is called once per frame
	void Update ()
    {
        //Keeps the camera's y level at a constant value.
        this.transform.position = new Vector3(transform.position.x, 4.36f, transform.position.z);
	}
}
