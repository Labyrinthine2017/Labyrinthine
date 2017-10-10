using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSound : MonoBehaviour
{
    private AudioSource source;
    private bool bPlay = false;

    void Awake()
    {
        bPlay = false;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && bPlay == true)
        {
            source.Play();
            bPlay = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            bPlay = true;
    }

    
}
