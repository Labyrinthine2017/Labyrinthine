using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Note : MonoBehaviour
{
    private bool collected;
    public bool IsCollected { get { return collected; } private set { collected = value; } }
    [SerializeField]private float coolantAmount = 1.0f;
    [SerializeField] ParticleSystem particles;
    float timer = 0.0f;

    private GameManager manager;
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        collected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<EngineBehaviour>().CoolEngineByAmount(coolantAmount);

            manager.comboScore += 1;
            manager.AddScore(10.0f);

            this.GetComponent<MeshRenderer>().enabled = false;


            var emission = particles.emission;
            if (particles.isPlaying == false)
            {
                emission.enabled = true;
                particles.Play(true);
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= 1.0f)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        if (transform.GetChild(i).tag == "Vechicle")
                        {
                            transform.GetChild(i).gameObject.SetActive(false);
                        }
                    }
                }
                if (timer >= 2.0f)
                {
                    emission.enabled = false;
                    particles.Play(false);

                }
            }

            collected = true;
        }
    }
}
