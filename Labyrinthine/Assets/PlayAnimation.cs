using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator anim;
    private bool crossed = false;
    private bool canLaser = true;
	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.L))
        {
            if (canLaser == true)
            {
                if (crossed == false)
                {
                    anim.SetTrigger("CrossLasers");
                    crossed = true;
                }
                else
                {
                    anim.SetTrigger("UncrossLasers");
                    crossed = false;
                }

                canLaser = false;
            }
        }
	}

    public void HideLaser()
    {
        //turn off particles
        //turn off collisions
        canLaser = true;
    }
}
