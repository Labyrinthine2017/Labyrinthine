using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float coolantAmount = 1.0f;
    bool beenMissed = false;
    bool controllerPresent = false;
    bool allowedToCollect = false;
    GameManager manager;
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        controllerPresent = manager.controller;
    }
    void Update()
    {
        if (allowedToCollect == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.gameObject.GetComponent<EngineBehaviour>().CoolEngineByAmount(coolantAmount);
                manager.comboScore += 1;
                manager.AddScore(10.0f);
                Destroy(this.gameObject);
            }
        }
        if (player.transform.position.z - 2.4f > transform.position.z && beenMissed == false)
        {
            manager.ResetCombo();
            beenMissed = true;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        allowedToCollect = true;
    }
    void OnTriggerExit(Collider col)
    {
        allowedToCollect = false;
    }
}
