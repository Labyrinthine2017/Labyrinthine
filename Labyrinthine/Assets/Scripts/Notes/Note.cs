using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float fuelEffectAmount = 1.0f;
    GameManager manager;
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    void FixedUpdate()
    {
        if(player.transform.position.z > transform.position.z)
        {
            manager.ResetCombo();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                col.GetComponent<EngineBehaviour>().CoolEngineByAmount(fuelEffectAmount);
                manager.comboScore += 1;
                Destroy(this.gameObject);
            }

        }
    }

}
