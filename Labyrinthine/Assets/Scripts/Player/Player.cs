using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FuelMonitoring fuelGague { get; set; }
    public PlayerMovement movement { get; set; }
	// Update is called once per frame
    void Start()
    {
        fuelGague = this.gameObject.GetComponent<FuelMonitoring>();
        movement = this.gameObject.GetComponent<PlayerMovement>();
    }

}
