using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    Vector3 vStartPos;

	void Start()
    {
        vStartPos = new Vector3(0, 0.38f, -899.97f);
	}
	
	void Update()
    { 
       
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tp")
        {
            transform.position = vStartPos;
        }
    }
}
