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
                Destroy(this.gameObject);
            }
            if (XCI.GetButtonDown(XboxButton.A/*, playerMovement.controller*/))
            {
                playerMovement.gameObject.GetComponent<EngineBehaviour>().CoolEngineByAmount(coolantAmount);
                manager.comboScore += 1;
                manager.AddScore(10.0f);
                Destroy(this.gameObject);
            }

            //hello
            
        }
        if (playerMovement.transform.position.z - 2.4f > transform.position.z && beenMissed == false)
        {
            manager.ResetCombo();
            beenMissed = true;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            allowedToCollect = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            allowedToCollect = false;
        }
    }

}
