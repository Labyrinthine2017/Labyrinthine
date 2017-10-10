using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverBeat : MonoBehaviour {

    public float fSpeedUp;
    public float fSpeedDown;
    private float f_timer;
    private bool bCheckWall;

    void Awake()
    {
        fSpeedUp = 3.0f;
        fSpeedDown = 2.5f;
        bCheckWall = false;
    }

    void Update()
    {
        if (bCheckWall == false)
            transform.Translate(0, fSpeedUp * Time.deltaTime, 0);

        if (bCheckWall == true)
            transform.Translate(0, -fSpeedDown * Time.deltaTime, 0);

    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "wall1")
            bCheckWall = true;

        if (col.gameObject.tag == "wall2")
            bCheckWall = false;
    }
}
