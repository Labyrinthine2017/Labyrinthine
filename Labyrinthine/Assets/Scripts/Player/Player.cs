using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement movement { get; set; }
    public EngineBehaviour engine { get; set; }
	// Update is called once per frame
    void Start()
    {
        movement = this.gameObject.GetComponent<PlayerMovement>();
        engine = this.gameObject.GetComponent<EngineBehaviour>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "End")
        {
            Time.timeScale = 0.0f;
        }
    }

}
