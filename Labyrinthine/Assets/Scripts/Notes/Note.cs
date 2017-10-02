using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float fuelEffectAmount = 1.0f;


    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                col.GetComponent<EngineBehaviour>().CoolEngineByAmount(fuelEffectAmount);
                Destroy(this.gameObject);
            }

        }
    }

}
