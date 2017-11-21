using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    private bool bPlay = false;

    void Awake()
    {
        bPlay = false;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(bPlay == true)
        {
            Camera.main.GetComponent<AudioSource>().Play();
           //AudioSource.PlayClipAtPoint(clip, transform.position);
           // source.PlayOneShot(clip, 1.0f);
           // bPlay = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            bPlay = true;
    }
}
