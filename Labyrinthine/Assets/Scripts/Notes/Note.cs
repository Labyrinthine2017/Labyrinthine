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
    private void Update()
    {
        if(collected)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            //Enables the particle emission of the note
            var emission = particles.emission;
            if (emission.enabled == false)
            {
                emission.enabled = true;
                particles.Play(true);
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= 2.0f)
                {
                    particles.gameObject.SetActive(false);
                    collected = false;
                }
            }          
        }
    }
    //Called from Player Script when the note has been hit
    public void Collected()
    {
        collected = true;
    }
}
