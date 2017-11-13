using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageImage : MonoBehaviour
{
    Image image;
    EngineBehaviour playerEngine;
	// Use this for initialization
	void Start ()
    {
        image = GetComponent<Image>();
        playerEngine = GameObject.FindGameObjectWithTag("Player").GetComponent<EngineBehaviour>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        image.fillAmount = 1 - (playerEngine.engineHeatAmount / 100.0f);
	}
}
