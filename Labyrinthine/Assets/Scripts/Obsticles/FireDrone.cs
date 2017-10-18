using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrone : MonoBehaviour
{
    [SerializeField] float heatDamage = 5.0f;
    [SerializeField] float timeBetweenActivations = 1.0f;
    [SerializeField] float timeOfActivation = 1.0f;
    BoxCollider myCollider;
    float timer = 0.0f;
	// Use this for initialization
	void Start ()
    {
        myCollider = this.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        timer += Time.deltaTime;
        if (myCollider.enabled == false && timer >= timeBetweenActivations)
        {
            timer = 0.0f;
            myCollider.enabled = true;
        }
        if (myCollider.enabled == true && timer >= timeOfActivation)
        {
            timer = 0.0f;
            myCollider.enabled = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<EngineBehaviour>().engineHeatAmount += heatDamage;
        }
    }
}
