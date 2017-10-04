using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Note : MonoBehaviour
{
    public float coolantAmount = 1.0f;
    bool beenMissed = false;
    bool allowedToCollect = false;
    GameManager manager;
    PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    void Update()
    {
        if (allowedToCollect == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerMovement.gameObject.GetComponent<EngineBehaviour>().CoolEngineByAmount(coolantAmount);
                manager.comboScore += 1;
                manager.AddScore(10.0f);
                this.GetComponent<MeshRenderer>().enabled = false;
            }
            if (XCI.GetButtonDown(XboxButton.A))
            {
                playerMovement.gameObject.GetComponent<EngineBehaviour>().CoolEngineByAmount(coolantAmount);
                manager.comboScore += 1;
                manager.AddScore(10.0f);
                this.GetComponent<MeshRenderer>().enabled = false;
            }

            //hello
            
        }
    }

    public void AllowedCollection(bool a_state)
    {
        allowedToCollect = a_state;
    }
}
