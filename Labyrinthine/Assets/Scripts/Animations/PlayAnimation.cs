using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{

    private bool canLaser = true;
    ParticleSystem[] lasers;
	// Use this for initialization
	void Start ()
    {
        lasers = GetComponentsInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.L))
        {
            if (canLaser == true)
            {
                foreach (ParticleSystem laser in lasers)
                {
                    if (laser.GetComponent<Laser>().GetState() == false)
                    {                        
                        laser.GetComponent<Animator>().SetTrigger("CrossLasers");
                        Debug.Log("Crossing Laser", laser.gameObject);
                    }
                    if(laser.GetComponent<Laser>().GetState() == true)
                    {                        
                        laser.GetComponent<Animator>().SetTrigger("UncrossLasers");
                        Debug.Log("Uncrossing Laser", laser.gameObject);
                    }
                }
            }
        }
	}
}
