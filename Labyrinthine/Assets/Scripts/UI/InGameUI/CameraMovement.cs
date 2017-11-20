using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] tTarget;
    public Transform tCar;
    private GameObject tp;
    private GameObject UIMenu;

    private Vector3 m_vMenuPos;
    private Vector3 m_vGamepos;

    public float fSpeed;
    private int nCurrent;
    private bool bStart = false;

    private void Awake()
    {
        transform.LookAt(tCar);
        m_vMenuPos = transform.position;
        m_vGamepos = new Vector3(0f, 0.38f, -11.5f);
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

                m_vMenuPos = m_vGamepos;
                this.enabled = false;
            }
        }     

	}


    
}
