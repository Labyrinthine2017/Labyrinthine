//=======================================================
//  File Author:     Brent Kingma 
//
//  File Name:       FadeImage
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    //creates variables for flash settings
    public float fadeInAmount = 0.1f;
    public float fadeOutAmount = 0.08f;
    public bool flash = false;

    float fadeAmount;

    Image image;
    Color original;
	// Use this for initialization for the flash effects 
	void Start ()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
        original = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
        fadeAmount = fadeInAmount;
        fadeOutAmount = -fadeOutAmount;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //manualy setting the variables or the colour and aplha to turn on and off
        if (flash)
        {
            Color color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + fadeAmount);
            image.color = color;
            //alpha is changed when its greater than 1f
            if (image.color.a >= 1)
            {
                fadeAmount = fadeOutAmount;
            }
            //alpha is changed when its less than 0f
            if (image.color.a <= 0)
            {
                fadeAmount = fadeInAmount;
                flash = false;
            }            
        }
	}

    //values are reset to original values 
    //& flash is set back to false
    public void ResetValues()
    {
        image.color = original;
        fadeAmount = fadeInAmount;
        if (fadeOutAmount > 0)
        {
            fadeOutAmount = -fadeOutAmount;
        }
        flash = false;
    }
}
