//=======================================================
//  File Author:     Mark Sturtz
//
//  File Name:       Credits
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{
    //Loads the current scene to the credits screen 
    public void CreditScene()
    {
        SceneManager.LoadScene(3);
    }
}