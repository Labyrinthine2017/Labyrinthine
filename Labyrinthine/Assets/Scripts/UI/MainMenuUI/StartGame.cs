using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{


    public void GameScene(int nIndexScene)
    {
        SceneManager.LoadScene(nIndexScene);
    }

    public void Awake()
    {
        
    }

    public void Update()
    {
        
    }

    public void StartSettings()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ResetScore();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().StartSounds();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ActivateParticleSystem();
    }
}
