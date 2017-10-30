using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameOption : MonoBehaviour
{
    private Image img;

    public void Awake()
    {
        img = GameObject.Find("GameUI").GetComponent<Image>();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           if(gameObject.tag == "InGameOption")
            {
                img.color = Color.blue;
            }
        }
	}
}
