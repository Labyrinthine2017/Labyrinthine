using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerMovement : MonoBehaviour
{

    public float ForwardMovementSpeed = 0.2f, DifferenceInXBetweenPlatforms = 3.39f, LeftRightMovementSpeed = 0.2f, HoverHeight = 2.0f, UpwardsSpeed = 0.2f;
    public bool hasController { get; set; }
    Vector3 vectorForConstantForwardMovement;
    Vector3 leftLanePos, rightLanePos, centreLanePos;
    Vector3 playerOrignalPosition;
    bool movingLeft = false, movingRight = false, hovering = false, isGrounded = true, allowedToJump = true;
    bool inLeftLane = false, inMidLane = true, inRightLane = false;
    float timer = 0.0f;
    float refreshJumpTimer = 0.0f;
    [SerializeField] bool magnatise = false;
    [SerializeField] float timeInAir = 0.5f;
    [SerializeField] float timeBetweenJumps = 2.0f;

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
        if ((Input.GetKeyDown(KeyCode.Space) || XCI.GetButtonDown(XboxButton.A)) && allowedToJump)
        {
            hovering = true;
            isGrounded = false;
            allowedToJump = false;
        }
        if (magnatise)
        {
            if (!XCI.IsPluggedIn(1))
            {
                //If both directions are being pressed
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
                        movingLeft = true;
                    }
                    else
                    {
                        movingLeft = false;
                    }
                    //Right Movement
                    if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                    {
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
        }     
        else if(!magnatise)
        {
            if (!XCI.IsPluggedIn(1))
            {
                if (transform.position.x == leftLanePos.x)
                {
                    if (movingLeft)
                    {
                        movingLeft = false;
                    }
                    inLeftLane = true;
                    inMidLane = false;
                    inRightLane = false;
                }
                if (transform.position.x == rightLanePos.x)
                {
                    if (movingRight)
                    {
                        movingRight = false;
                    }
                    inLeftLane = false;
                    inMidLane = false;
                    inRightLane = true;
                }
                if (transform.position.x == centreLanePos.x)
                {
                    inLeftLane = false;
                    inMidLane = true;
                    inRightLane = false;
                }
            }
            else
            {
                if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && (!inLeftLane || !inMidLane))
                {
                    movingLeft = true;
                }
                if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && (!inMidLane || !inRightLane))
                {
                    movingRight = true;
                }
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
        }
    }
	void FixedUpdate ()
    {
        //Constant forward movement
        transform.Translate(Vector3.forward * ForwardMovementSpeed * Time.fixedDeltaTime);
        //Leftwards movement
        if (movingLeft)
        {
            if (inMidLane && !inLeftLane)
            {
                if (transform.position.x > leftLanePos.x)
                {
                    transform.Translate(Vector3.left * LeftRightMovementSpeed * Time.fixedDeltaTime);
                    if (transform.position.x < leftLanePos.x)
                    {
                        transform.position = new Vector3(leftLanePos.x, transform.position.y, transform.position.z);
                        movingLeft = false;
                    }
                }
            }
            if(inRightLane && !inMidLane)
            {
                if (transform.position.x > centreLanePos.x)
                {
                    transform.Translate(Vector3.left * LeftRightMovementSpeed * Time.fixedDeltaTime);
                    if (transform.position.x < centreLanePos.x)
                    {
                        transform.position = new Vector3(centreLanePos.x, transform.position.y, transform.position.z);
                        movingLeft = false;
                    }
                }
            }
        }
        //Rightwards movement
        if (movingRight)
        {
            if (inMidLane && !inRightLane)
            {
                if (transform.position.x < rightLanePos.x)
                {
                    transform.Translate(Vector3.right * LeftRightMovementSpeed * Time.fixedDeltaTime);
                    if (transform.position.x > rightLanePos.x)
                    {
                        transform.position = new Vector3(rightLanePos.x, transform.position.y, transform.position.z);
                        movingRight = false;
                    }
                }
            }
            if(inLeftLane && !inMidLane)
            {
                if (transform.position.x < centreLanePos.x)
                {
                    transform.Translate(Vector3.right * LeftRightMovementSpeed * Time.fixedDeltaTime);
                    if (transform.position.x > centreLanePos.x)
                    {
                        transform.position = new Vector3(centreLanePos.x, transform.position.y, transform.position.z);
                        movingRight = false;
                    }
                }
            }
        }
        if (magnatise)
        {
            //Returns to original position
            if (!movingRight && !movingLeft)
            {
                //Moves from left to center
                if (transform.position.x < centreLanePos.x)
                {
                    transform.Translate(Vector3.right * LeftRightMovementSpeed * Time.fixedDeltaTime);
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
                    transform.Translate(Vector3.left * LeftRightMovementSpeed * Time.fixedDeltaTime);
                    movingLeft = false;
                    movingRight = false;
                    if (transform.position.x < centreLanePos.x)
                    {
                        transform.position = new Vector3(centreLanePos.x, transform.position.y, transform.position.z);
                    }
                }
            }
        }

        //Hovering
        if(hovering)
        {
            //If the player goes higher
            if(transform.position.y < playerOrignalPosition.y + HoverHeight)
            {
                transform.Translate(Vector3.up * UpwardsSpeed * Time.fixedDeltaTime);               
            }
            else
            {
                transform.position = new Vector3(transform.position.x, playerOrignalPosition.y + HoverHeight, transform.position.z);
                timer += Time.fixedDeltaTime;
            }
            if(timer >= timeInAir)
            {
                hovering = false;
                timer = 0.0f;
            }

        }
        else
        {
            if (transform.position.y > playerOrignalPosition.y)
            {
                transform.Translate(Vector3.down * UpwardsSpeed * Time.fixedDeltaTime);
            }
            if(transform.position.y == playerOrignalPosition.y && !isGrounded)
            {
                isGrounded = true;
            }
            if(isGrounded && !allowedToJump)
            {
                refreshJumpTimer += Time.fixedDeltaTime;
            }
            if(refreshJumpTimer >= timeBetweenJumps)
            {
                allowedToJump = true;
                refreshJumpTimer = 0.0f;
            }
        }
    }
}
