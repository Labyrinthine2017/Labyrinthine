using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float ForwardMovementSpeed = 0.2f, DifferenceInZBetweenPlatforms = 2.0f;
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(new Vector3(-ForwardMovementSpeed, 0.0f, 0.0f));
        //Checks if the left arrow key is pressed
		if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(0.0f, 0.0f, DifferenceInZBetweenPlatforms);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.0f, 0.0f, DifferenceInZBetweenPlatforms);
        }
	}
}
