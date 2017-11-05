using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] tTarget;
    public float fSpeed;
    private int nCurrent;

	void Update ()
    {
        if (transform.position != tTarget[nCurrent].position)
        {
            Vector3 vPos = Vector3.MoveTowards(transform.position, tTarget[nCurrent].position, fSpeed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(vPos);
        }
        else nCurrent = (nCurrent + 1) % tTarget.Length;
	}
}
