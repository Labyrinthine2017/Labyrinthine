using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeathParticles : MonoBehaviour
{
    //This class is for the activation of the death particle and the disabling of the player object
    [SerializeField]ParticleSystem myParticle;
    EngineBehaviour myEngine;
    float timer = 0.0f;
    private void Awake()
    {
        myEngine = GetComponent<EngineBehaviour>();
    }
    // Update is called once per frame
    private void Update()
    {
        if(myEngine.engineHeatAmount >= 100.0f)
        {
            var emission = myParticle.emission;
            
            if (myParticle.isPlaying == false)
            {                
                emission.enabled = true;
                myParticle.Play(true);
            }
            else
            {
                timer += Time.deltaTime;
                if(timer >= 1.0f)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        if (transform.GetChild(i).tag == "Vechicle")
                        {
                            transform.GetChild(i).gameObject.SetActive(false);
                        }
                    }
                }
                if(timer >= 2.0f)
                {
                    emission.enabled = false;
                    myParticle.Play(false);
                    
                }
            }
        }
    }
}
