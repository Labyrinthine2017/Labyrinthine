using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Note : MonoBehaviour
{
    public float coolantAmount = 1.0f;
    bool beenMissed = false;
    bool controllerPresent = false;
    bool allowedToCollect = false;
    GameManager manager;
    PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        controllerPresent = manager.controller;
    }
    void Update()
    {
        if (allowedToCollect == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                playerMovement.gameObject.GetComponent<EngineBehaviour>().CoolEngineByAmount(coolantAmount);
                manager.comboScore += 1;
                manager.AddScore(10.0f);
                Destroy(this.gameObject);
            }
            if(controllerPresent)
            {
                if (playerMovement.state.Buttons.A == ButtonState.Pressed)
                {
                    playerMovement.gameObject.GetComponent<EngineBehaviour>().CoolEngineByAmount(coolantAmount);
                    manager.comboScore += 1;
                    manager.AddScore(10.0f);
                    Destroy(this.gameObject);
                }
            }
        }
        if (playerMovement.transform.position.z - 2.4f > transform.position.z && beenMissed == false)
        {
            manager.ResetCombo();
            beenMissed = true;
        }
    }
    //void OnTriggerEnter(Collider col)
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) == false)
    //    {
    //        allowedToCollect = true;
    //    }
    //}
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            allowedToCollect = false;
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" && !Input.GetKey(KeyCode.Space))
        {
            allowedToCollect = true;
        }
    }
}
