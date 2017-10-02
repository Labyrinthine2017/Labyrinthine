using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerMovement : MonoBehaviour
{

    public float ForwardMovementSpeed = 0.2f, DifferenceInXBetweenPlatforms = 3.39f;
    //For PC
    /// <summary>
    /// Storage for the distance in movement
    /// </summary>
    Vector3 vectorForConstantForwardMovement;
    Vector3 leftLanePos, rightLanePos, centreLanePos;
    Vector3 playerOrignalPosition;
    bool movingLeft = false, movingRight = false;

    //For Xbox360 controller
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    // Update is called once per frame
    void Start()
    {
        vectorForConstantForwardMovement = new Vector3(DifferenceInXBetweenPlatforms, 0.0f, 0.0f);
        playerOrignalPosition = transform.position;
        leftLanePos = playerOrignalPosition - vectorForConstantForwardMovement;
        rightLanePos = playerOrignalPosition + vectorForConstantForwardMovement;
        centreLanePos = playerOrignalPosition;
    }
    void Update()
    {

        if(Debug.isDebugBuild)
        {
            vectorForConstantForwardMovement = new Vector3(DifferenceInXBetweenPlatforms, 0.0f, 0.0f);
            //Debug.Log("IN DEBUG MODE");
        }
        //Checking if a controller is connected
        if (!playerIndexSet || !prevState.IsConnected)
        {
            PlayerIndex testPlayerIndex = (PlayerIndex)0;
            GamePadState testState = GamePad.GetState(testPlayerIndex);
            if (testState.IsConnected)
            {
                Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                playerIndex = testPlayerIndex;
                playerIndexSet = true;
            }
        }

        if (!playerIndexSet)//No controller
        {
            //Left Movement
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                //transform.position = transform.position - movement;
                movingLeft = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                //transform.position = transform.position + movement;
                movingLeft = false;
            }
            //Right Movement
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                //transform.position = transform.position + movement;
                movingRight = true;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                //transform.position = transform.position - movement;
                movingRight = false;
            }
        }
        else//Has controller
        {
            prevState = state;
            state = GamePad.GetState(playerIndex);

            Debug.Log(state.ThumbSticks.Left.X);

            if (state.ThumbSticks.Left.X < 0.0f)
            {
                movingLeft = true;
                movingRight = false;
            }
            if(state.ThumbSticks.Left.X > 0.0f)
            {
                movingRight = true;
                movingLeft = false;
            }
            if(state.ThumbSticks.Left.X == 0.0f)
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
                transform.Translate(Vector3.left * 0.2f);
            }
        }
        //Rightwards movement
        if (movingRight)
        {
            if (transform.position.x < rightLanePos.x)
            {
                transform.Translate(Vector3.right * 0.2f);
            }
        }
        //Returns to original position
        if (!movingRight && !movingLeft)
        {
            //Moves from left to center
            if (transform.position.x < centreLanePos.x)
            {
                transform.Translate(Vector3.right * 0.2f);
            }
            //Moves from right to center
            if (transform.position.x > centreLanePos.x)
            {
                transform.Translate(Vector3.left * 0.2f);
            }
        }
    }
	void FixedUpdate ()
    {
        //Constant forward movement
        transform.Translate(Vector3.forward * ForwardMovementSpeed);
	}
}
