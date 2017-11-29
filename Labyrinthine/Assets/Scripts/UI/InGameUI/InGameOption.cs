//=======================================================
//  File Author:     Mark Sturtz 
//
//  File Name:       InGameOption
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Continue option variables for ingame button 
[System.Serializable]
public class ContinueOption
{
    public string sUnpause = "";

    public float X_Value;
    public float Y_Value;

    public float Width;
    public float Height;
};

//Option option variables for ingame button
[System.Serializable]
public class OptionsOption
{
    public string sOptions = "";

    public float X_Value;
    public float Y_Value;

    public float Width;
    public float Height;
};

//MainMenu option variables for ingame button
[System.Serializable]
public class MainMenuOption
{
    public string sMainMenu = "";

    public float X_Value;
    public float Y_Value;

    public float Width;
    public float Height;
};

public class InGameOption : MonoBehaviour
{
    //calling all the previous classes  & setting a paused boolean
    private bool bPaused = false;

    public ContinueOption Continue;
    public OptionsOption Option;
    public MainMenuOption MainMenu;

    private void Awake()
    {
        //===========================================
        // setting all of the values of each coordinate 
        // to the centre screen
        //
        // names are given for each GUI button
        //===========================================
        Continue.X_Value = 440.0f;
        Continue.Y_Value = 170.0f;
        Continue.Width = 200.0f;
        Continue.Height = 40.0f;

        Option.X_Value = 440.0f;
        Option.Y_Value = 220.0f;
        Option.Width = 200.0f;
        Option.Height = 40.0f;
   
        MainMenu.X_Value = 440.0f;
        MainMenu.Y_Value = 270.0f;
        MainMenu.Width = 200.0f;
        MainMenu.Height = 40.0f;

        Option.sOptions = "Options";
        Continue.sUnpause = "Continue";
        MainMenu.sMainMenu = "Main Menu";
    }

    void Update()
    {
        //toggles the pause by passing a function
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            bPaused = TogglePause();
        }
	}

    private void OnGUI()
    {
        //===========================================
        //  if bPaused = true, 
        //  
        //  creates the boxes for each option available
        //  being menu, continue & exit
        //===========================================
        if (bPaused)
        {
            GUILayout.Label("Game is Paused");

            if(GUI.Button(new Rect(Continue.X_Value, Continue.Y_Value, Continue.Width, Continue.Height), Continue.sUnpause))
            {
                bPaused = TogglePause();
            }

            if(GUI.Button(new Rect(Option.X_Value, Option.Y_Value, Option.Width, Option.Height), Option.sOptions)){}

            if (GUI.Button(new Rect(MainMenu.X_Value, MainMenu.Y_Value, MainMenu.Width, MainMenu.Height), MainMenu.sMainMenu))
            {
                SceneManager.LoadScene(1);
                bPaused = TogglePause();    
            }
        }
    }
    //function acts as a toggle for the timescale in-game GUI/pause menu
    public bool TogglePause()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            return false;
        }
        else
        {
            Time.timeScale = 0;
            return true;
        }
    }
}