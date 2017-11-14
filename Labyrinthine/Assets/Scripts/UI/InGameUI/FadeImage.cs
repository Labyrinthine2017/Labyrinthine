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
	// Use this for initialization
	void Start ()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
        fadeAmount = fadeInAmount;
        fadeOutAmount = -fadeOutAmount;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(image.color.a);
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
}
