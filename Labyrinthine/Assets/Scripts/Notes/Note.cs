using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Note : MonoBehaviour
{
    private bool collected;
    public bool IsCollected { get { return collected; } private set { collected = value; } }
    
    [SerializeField] ParticleSystem particles;
    float timer = 0.0f;
    
    void Awake()
    {
        collected = false;
    }

    //Called from Player Script when the note has been hit
    public void Collected()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        //Enables the particle emission of the note
        var emission = particles.emission;
        if (particles.isPlaying == false)
        {
            emission.enabled = true;
            particles.Play(true);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= 2.0f)
            {
                emission.enabled = false;
                particles.Play(false);
            }
        }
        collected = true;
    }
}
