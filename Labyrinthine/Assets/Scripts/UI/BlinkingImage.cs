using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingImage : MonoBehaviour
{
    Image myImage;
    public float delayTime;
    float time;
    public float waitTimeBetweenFlashes;
    bool flashed = false;

    // Use this for initialization
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

    void ToggleState()
    {
        myImage.enabled = !myImage.enabled;
    }
}
