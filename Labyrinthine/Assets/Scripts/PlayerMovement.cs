using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float ForwardMovementSpeed = 0.2f, DifferenceInXBetweenPlatforms = 3.4f;
    /// <summary>
    /// Storage for the distance in movement
    /// </summary>
    Vector3 movement;
	// Update is called once per frame
    void Start()
    {
        movement = new Vector3(DifferenceInXBetweenPlatforms, 0.0f, 0.0f);
    }
    void Update()
    {
        if(Debug.isDebugBuild)
        {
            movement = new Vector3(DifferenceInXBetweenPlatforms, 0.0f, 0.0f);
            Debug.Log("IN DEBUG MODE");
        }
        //Left Movement
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.position = transform.position - movement;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            transform.position = transform.position + movement;
        }
        //Right Movement
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.position = transform.position + movement;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            transform.position = transform.position - movement;
        }
    }
	void FixedUpdate ()
    {
        transform.Translate(Vector3.forward * ForwardMovementSpeed);
	}
}
