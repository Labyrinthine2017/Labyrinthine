using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private Vector3 vStartPos;

	void Start()
    {
        vStartPos = new Vector3(0f, 0.3800001f, -11.5f);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tp")
        {
            transform.position = vStartPos;
        }
    }
}
