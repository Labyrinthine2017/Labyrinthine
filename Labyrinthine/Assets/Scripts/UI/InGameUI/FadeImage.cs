using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    Image image;
    public float fadeInAmount = 0.1f;
    public float fadeOutAmount = 0.08f;
    float fadeAmount;
    public bool flash = false;
    Color original;
	// Use this for initialization
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
        if (flash)
        {
            Color color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + fadeAmount);
            image.color = color;
            if (image.color.a >= 1)
            {
                fadeAmount = fadeOutAmount;
            }
            if (image.color.a <= 0)
            {
                fadeAmount = fadeInAmount;
                flash = false;
            }            
        }
	}

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
