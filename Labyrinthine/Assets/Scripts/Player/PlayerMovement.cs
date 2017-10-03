using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerMovement : MonoBehaviour
{

    public float ForwardMovementSpeed = 0.2f, DifferenceInXBetweenPlatforms = 3.39f, LeftRightMovementSpeed = 0.2f;
    public bool hasController { get; set; }
    //For PC
    /// <summary>
    /// Storage for the distance in movement
    /// </summary>
    Vector3 vectorForConstantForwardMovement;
    Vector3 leftLanePos, rightLanePos, centreLanePos;
    Vector3 playerOrignalPosition;
    bool movingLeft = false, movingRight = false;

    //For Xbox360 controller
    public XboxController controller { get; set; }


    // Update is called once per frame
    void Start()
    {
        vectorForConstantForwardMovement = new Vector3(DifferenceInXBetweenPlatforms, 0.0f, 0.0f);
        playerOrignalPosition = transform.position;
        leftLanePos = playerOrignalPosition - vectorForConstantForwardMovement;
        rightLanePos = playerOrignalPosition + vectorForConstantForwardMovement;
        centreLanePos = playerOrignalPosition;
        controller = XboxController.First;
    }
    void Update()
    {
        if(Debug.isDebugBuild)
        {
            vectorForConstantForwardMovement = new Vector3(DifferenceInXBetweenPlatforms, 0.0f, 0.0f);
            //Debug.Log("IN DEBUG MODE");
        }
        if (controller != XboxController.Any)
        {
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                movingLeft = false;
                movingRight = false;
            }
            else
            {
                //Left Movement
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    //transform.position = transform.position - movement;
                    movingLeft = true;
                }
                else
                {
                    movingLeft = false;
                }
                //Right Movement
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    //transform.position = transform.position + movement;
                    movingRight = true;
                }
                else
                {
                    movingRight = false;
                }
            }
        }
        else
        {
            if (XCI.GetAxisRaw(XboxAxis.LeftStickX, controller) < 0.0f)
            {
                movingLeft = true;
                movingRight = false;
            }
            if (XCI.GetAxisRaw(XboxAxis.LeftStickX, controller) > 0.0f)
            {
                movingRight = true;
                movingLeft = false;
            }
            if (XCI.GetAxisRaw(XboxAxis.LeftStickX, controller) == 0.0f)
            {
                movingLeft = false;
                movingRight = false;
            }
        }
        
        //Leftwards movement
        if (movingLeft)
        {
            if (transform.position.x > leftLanePos.x)
            {
                transform.Translate(Vector3.left * LeftRightMovementSpeed);
                if(transform.position.x < leftLanePos.x)
                {
                    transform.position = new Vector3(leftLanePos.x, transform.position.y, transform.position.z);
                }
            }
        }
        //Rightwards movement
        if (movingRight)
        {
            if (transform.position.x < rightLanePos.x)
            {
                transform.Translate(Vector3.right * LeftRightMovementSpeed);
                if (transform.position.x > rightLanePos.x)
                {
                    transform.position = new Vector3(rightLanePos.x, transform.position.y, transform.position.z);
                }
            }
        }
        //Returns to original position
        if (!movingRight && !movingLeft)
        {
            //Moves from left to center
            if (transform.position.x < centreLanePos.x)
            {
                transform.Translate(Vector3.right * LeftRightMovementSpeed);
                movingLeft = false;
                movingRight = false;
                if (transform.position.x > centreLanePos.x)
                {
                    transform.position = new Vector3(centreLanePos.x, transform.position.y, transform.position.z);
                }
            }
            //Moves from right to center
            if (transform.position.x > centreLanePos.x)
            {
                transform.Translate(Vector3.left * LeftRightMovementSpeed);
                movingLeft = false;
                movingRight = false;
                if (transform.position.x < centreLanePos.x)
                {
                    transform.position = new Vector3(centreLanePos.x, transform.position.y, transform.position.z);
                }
            }
        }
    }
	void FixedUpdate ()
    {
        //Constant forward movement
        transform.Translate(Vector3.forward * ForwardMovementSpeed);
	}
}
