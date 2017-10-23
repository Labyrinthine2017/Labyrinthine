using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Note : MonoBehaviour
{
    public float coolantAmount = 1.0f;
    bool allowedToCollect = false;
    public bool collected { get; set; }
    GameManager manager;
    PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        collected = false;
    }

    public void AllowedCollection(bool a_state)
    {
        allowedToCollect = a_state;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerMovement.gameObject.GetComponent<EngineBehaviour>().CoolEngineByAmount(coolantAmount);
            manager.comboScore += 1;
            manager.AddScore(10.0f);
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponentInChildren<Light>().enabled = false;
            collected = true;
        }
    }
}
