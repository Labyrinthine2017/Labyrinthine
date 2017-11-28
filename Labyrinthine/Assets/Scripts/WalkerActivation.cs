using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerActivation : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator anim;
    [SerializeField] float distanceView;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Vector3.Distance(player.transform.position, this.transform.position) < distanceView)
        {
            anim.SetBool("Walk", true);
        }
	}
}
