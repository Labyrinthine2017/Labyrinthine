using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using SceneManagement


public class ResetScene : MonoBehaviour
{
    //public string that allows Designers to change the scene name 
    private string SceneName = "Rad_City_023";

    //Apon Key "R" the scene will reset and load the selected scene name
	void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneName);
        }
            
	}

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneName);
    }
}
