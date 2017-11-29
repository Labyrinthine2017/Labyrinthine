//=======================================================
//  File Author:     Mark Sturtz
//
//  File Name:       NoteSound
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    //sets a play boolean 
    private bool bPlay = false;

    void Awake()
    {
        bPlay = false;
        source = GetComponent<AudioSource>();
    }

    //plays the audio source when the boolean bPlay = true
    void Update()
    {
        if(bPlay == true)
        {
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }

    //ontrigger enter allows for notes to play sounds on pickup 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            bPlay = true;
    }
}
