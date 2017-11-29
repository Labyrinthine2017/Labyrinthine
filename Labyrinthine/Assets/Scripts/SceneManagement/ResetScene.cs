//=======================================================
//  File Author:     Mark Sturtz
//
//  File Name:       ResetScene
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    //public string that allows Designers to change the scene name 
    private int SceneName = 0;

    //Apon Key "R" the scene will reset and load the selected scene name
	void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
			SceneManager.LoadScene(SceneName);
        }   
	}
    //Reset function for onclick event button
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneName);
    }
}
