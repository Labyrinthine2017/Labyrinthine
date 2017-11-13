using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] tTarget;
    public Transform tCar;
    private GameObject tp;
    private GameObject UIMenu;

    public float fSpeed;
    private int nCurrent;
    public bool bStart = false;

    private void Awake()
    {
        transform.LookAt(tCar);
    }

    public void StartGame()
    {
        bStart = true;
        tp = GameObject.FindWithTag("tp");
        UIMenu = GameObject.FindWithTag("MenuTag");
    }

	void Update ()
    {
        if(bStart)
        {
            if (Vector3.Distance(transform.position, tTarget[nCurrent].position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, tTarget[nCurrent].position, fSpeed * Time.deltaTime);
                transform.LookAt(tCar);

                Destroy(tp);
                Destroy(UIMenu);
            }
            else
            {
                transform.position = tTarget[nCurrent].position;
                transform.LookAt(tCar);
                nCurrent = (nCurrent + 1) % tTarget.Length;
            }
        }

	}


    
}
