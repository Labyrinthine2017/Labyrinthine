//=======================================================
//  File Author:     Mark Sturtz 
//
//  File Name:       StartGame
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //loads the start of the current scene
    public void GameScene(int nIndexScene)
    {
        SceneManager.LoadScene(nIndexScene);
    }

    //settings that find the objects and calls for functions
    public void StartSettings()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ResetScore();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().StartSounds();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ActivateParticleSystem();
    }
}
