//=======================================================
//  File Author:     Mark Sturtz
//
//  File Name:       Camera Movement
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{

    //public private variables 
    public int m_nMusicDelay = 1;
    public float fSpeed;
    public Transform[] tTarget;
    public Transform tCar;
    public GameObject GUITag;

    private GameObject tp;
    private GameObject UIMenu;
    private GameObject m_goPlayerpos;
    private Vector3 m_vMenuPos;
    private Vector3 m_vGamepos;
    private int nCurrent;
    private bool bStart = false;

    private void Awake()
    {
        //On awake the camera will look at the desired transform
        transform.LookAt(tCar);
        //menu and game positions are set for the camera
        m_vMenuPos = transform.position;
        m_vGamepos = new Vector3(0f, 0.38f, -21.05f);
        //finds the player tag
        m_goPlayerpos = GameObject.FindWithTag("Player");
    }

    //audio gets delayed outside the function
    private void DelayedAudio()
    {
        GetComponent<AudioSource>().Play();
    }

    public void StartGame()
    {
        //IUnvoke function lets the function be delayed in ints for seconds
		Invoke("DelayedAudio", m_nMusicDelay);
        //when menu closes it will activate a boolean to run the player controls 
        transform.parent.SendMessage("MenuEnd", SendMessageOptions.DontRequireReceiver);
        //start of the camera is set to true
        bStart = true;
        //finds the teleport tag to the gameobject
        tp = GameObject.FindWithTag("tp");
        //finds the UI tag to the gameobject
        UIMenu = GameObject.FindWithTag("MenuTag");
    }

	void Update ()
    {
        //===========================================================================
        //  if bStart is = true, 
        //
        //    camera will move towards the camera's desired transform.position
        //    GUI is set to true, revaling GUI & both box collider and UI menu 
        //    is destroyed allowing for the game to start
        //===========================================================================
        if (bStart)
        {
           if (Vector3.Distance(transform.position, tTarget[nCurrent].position) > 0.1f)
           {              
                transform.position = Vector3.MoveTowards(transform.position, tTarget[nCurrent].position, fSpeed * Time.deltaTime);
                transform.LookAt(tCar);
                
                GUITag.SetActive(true);
                m_goPlayerpos.transform.position = m_vGamepos;

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
    //if bStart is = true then the music is played once the play button is hit
    private void OnTriggerEnter(Collider other)
    {
        if(bStart)
        {
            if (gameObject.tag == "PlayMusic")
                 other.isTrigger = true;
        }
    }
}
