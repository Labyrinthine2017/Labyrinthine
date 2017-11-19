using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private Vector3 vStartPos;

	void Start()
    {
        vStartPos = new Vector3(15.49608f, -10.62763f, -881.07f);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tp")
        {
            transform.position = vStartPos;
        }
    }
}
