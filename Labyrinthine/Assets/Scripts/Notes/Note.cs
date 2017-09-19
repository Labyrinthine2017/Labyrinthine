using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField]
    float fuelEffectAmount;


    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                col.GetComponent<FuelMonitoring>().AlterFuelAmount(fuelEffectAmount);
                Destroy(this.gameObject);
            }

        }
    }

}
