﻿//=======================================================
//  File Author:     Brent Kingma 
//
//  File Name:       BlinkingImage
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingImage : MonoBehaviour
{
    Image myImage;
    public float delayTime;
    public float waitTimeBetweenFlashes;
    float time;
    bool flashed = false;

    // Use this for initialization to get component of myImage
    void Awake ()
    {
        myImage = gameObject.GetComponent<Image>();
	}


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= waitTimeBetweenFlashes && flashed == false)
        {
            ToggleState();
            time = 0.0f;
            flashed = true;
        }
        if(time >= delayTime && flashed == true)
        {
            ToggleState();
            time = 0.0f;
            flashed = false;
        }
       
    }

    //togles the blinking effect 
    void ToggleState()
    {
        if (myImage)
            myImage.enabled = !myImage.enabled;
    }

    //switches the blinking effect off 
    public void SwitchOff()
    {
        if(myImage)
            myImage.enabled = false;
    }
}
