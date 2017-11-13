using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Note : MonoBehaviour
{
    private bool collected;
    public bool IsCollected { get { return collected; } private set { collected = value; } }
    [SerializeField]private float coolantAmount = 1.0f;

    private GameManager manager;
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        collected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<EngineBehaviour>().CoolEngineByAmount(coolantAmount);

            manager.comboScore += 1;
            manager.AddScore(10.0f);

            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponentInChildren<Light>().enabled = false;

            collected = true;
        }
    }
}
