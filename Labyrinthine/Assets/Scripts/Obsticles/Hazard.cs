using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    [SerializeField] private float heatDamage = 5.0f;
    [SerializeField] FadeImage hazard;
    //[SerializeField] private float timeBetweenActivations = 1.0f;
    //[SerializeField] private float timeOfActivation = 1.0f;

    private BoxCollider myCollider;
    private float timer = 0.0f;

    void Start()
    {
        myCollider = this.GetComponent<BoxCollider>();
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            hazard.flash = true;
            col.gameObject.GetComponent<EngineBehaviour>().engineHeatAmount += heatDamage;
        }
    }
}
