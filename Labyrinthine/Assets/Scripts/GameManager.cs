//=======================================================
//  File Author:     Brent Kingma 
//
//  File Name:       GameManager
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int combo2Score = 5, combo3Score = 12, combo4Score = 23;

    float gameScore             { get; set; }
    public int comboScore       { get; set; }
    public int comboValue       { get; set; }
    public bool controller      { get; set; }
    float globalTime;
    float scoreTimer;
    bool showInfo = false;
    bool allowScoring = true;

    //Values for restart
    Transform playerTransformSave;


    [SerializeField] float distanceBetweenObjects = 250.0f;
    public GameObject[] parentArray;

    GameObject[] allObjects;

    //For UI -----------------------------------------------------------
    // instantiates the text that shows for the UI
    bool startedWarningSt1Blink = false;
    bool startedWarningSt2Blink = false;
    bool showedStreak = false;
    bool showed5combo = false;
    bool showed12combo = false;
    bool showed19combo = false;
    public bool isDead { get; set; }

    float timerStreak;
    [SerializeField] Image WarningSt1;
    [SerializeField] BlinkingImage WarningSt2;
    [SerializeField] Text scoreText;

    [SerializeField] Image multiplier;
    [SerializeField] Sprite x2Multiplier;
    [SerializeField] Sprite x3Multiplier;
    [SerializeField] Sprite x4Multiplier;
    [SerializeField] Image streak;
    [SerializeField] Sprite x5NoteStreak;
    [SerializeField] Sprite x12NoteStreak;
    [SerializeField] Sprite x19NoteStreak;
    Sprite defualt = null;


    //------------------------------------------------------------------

    //creates instance of the player & player engine 
    Player player;
    EngineBehaviour playerEngine;

    void Start()
    {
        //sets the variables for the start of the game menu 
        Application.targetFrameRate = 60;
        comboValue = 1;
        globalTime = 0.0f;
        gameScore = 0;
        streak.enabled = false;
        isDead = false;
        allObjects = (GameObject[])Resources.FindObjectsOfTypeAll(typeof(GameObject));
    }

    void Awake()
    {
        //instantiates the engine and player 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerEngine = GameObject.FindGameObjectWithTag("Player").GetComponent<EngineBehaviour>();
    }
    //======================================================
    // on update, the timers are set to deltaTime 
    // Checks if the player is dead
    // Adds the combo scores together if notes are hit
    //======================================================
    void Update()
    {
        if (!player.finished)
        {
            globalTime += Time.deltaTime;
            scoreTimer += Time.deltaTime;
            if (playerEngine.engineHeatAmount < 100.0f)
            {
                //Every half second you get a point
                if (scoreTimer >= 0.5f)
                {
                    if (allowScoring)
                    {
                        gameScore++;
                        scoreTimer = 0.0f;
                    }
                }
            }
            if (playerEngine.engineHeatAmount >= 100.0f)
            {
                isDead = true;
            }
            if (comboScore == combo2Score)
            {
                comboValue = 2;
            }
            if (comboScore == combo3Score)
            {
                comboValue = 3;
            }
            if (comboScore == combo4Score)
            {
                comboValue = 4;
            }

            for (int i = 0; i < parentArray.Length; i++)
            {
                for (int j = 0; j < parentArray[i].transform.childCount; j++)
                {
                    if (Vector3.Distance(parentArray[i].transform.GetChild(j).transform.position, player.transform.position) <= distanceBetweenObjects)
                    {
                        parentArray[i].transform.GetChild(j).gameObject.SetActive(true);
                    }
                    else
                    {
                        parentArray[i].transform.GetChild(j).gameObject.SetActive(false);
                    }
                    if (parentArray[i].transform.GetChild(j).transform.position.z < player.transform.position.z - 40.0f)
                    {
                        parentArray[i].transform.GetChild(j).gameObject.SetActive(false);
                    }
                }
            }
        }

        
    }
    void FixedUpdate()
    {
        //Runs UI Update once a frame
        UpdateUI();
    }

    //adds the score and combo values together 
    public void AddScore(float a_score)
    {
        gameScore += a_score * comboValue;
    }
    
    //subtracts the score if the combo is broken
    public void SubtractScore(float a_score)
    {
        gameScore -= a_score;
    }

    //resets the combo to the basic values
    public void ResetCombo()
    {
        comboValue = 1;
        comboScore = 0;
        showed5combo = false;
        showed12combo = false;
        showed19combo = false;
    }

    //Updates the UI element of the values for the player
    void UpdateUI()
    {
        //Set the score text field
        scoreText.text = gameScore.ToString();

        //Set multiplier sprite to the appropriate combo 
        if (comboValue == 1)
        {
            multiplier.enabled = false;
        }
        else
        {
            multiplier.enabled = true;
        }
        if (comboValue == 2)
        {
            multiplier.sprite = x2Multiplier;
            multiplier.SetNativeSize();
            //multiplier.rectTransform.position = new Vector3(multiplier.rectTransform.position.x, multiplier.rectTransform.position.y - 400, multiplier.rectTransform.position.z);
        }
        if (comboValue == 3)
        {
            multiplier.sprite = x3Multiplier;
        }
        if (comboValue == 4)
        {
            multiplier.sprite = x4Multiplier;
        }
        //----------------------------------------------

        //Set streak sprite to the appropriate streak

        if (comboScore == 5 && showed5combo == false)
        {
            streak.enabled = true;
            streak.sprite = x5NoteStreak;
            showedStreak = true;
            showed5combo = true;
            streak.SetNativeSize();
        }
        else if (comboScore == 12 && showed12combo == false)
        {
            streak.enabled = true;
            showedStreak = true;
            showed12combo = true;
            streak.sprite = x12NoteStreak;
        }
        else if (comboScore == 19 && showed19combo == false)
        {
            streak.enabled = true;
            showedStreak = true;
            showed19combo = true;
            streak.sprite = x19NoteStreak;
        }

        if (showedStreak)
        {
            timerStreak += Time.deltaTime;
        }
        if (timerStreak >= 2.0f)
        {
            streak.enabled = false;
            showedStreak = false;
            timerStreak = 0.0f;
        }
        //--------------------------------------------

        //Red bar = 147
        //Used to enable and disable the warning words to appear
        if (playerEngine.engineHeatAmount > 81.1f)
        {
            WarningSt2.enabled = true;
            startedWarningSt2Blink = true;
        }
        else if (playerEngine.engineHeatAmount < 81.1f)
        {
            WarningSt2.enabled = false;
            startedWarningSt2Blink = false;
        }
        //Warning bar = 169
        //Used to enable and disable the blinking warning red border
        if (playerEngine.engineHeatAmount > 93.8f)
        {
            WarningSt1.enabled = true;
            startedWarningSt1Blink = true;
        }
        else if (playerEngine.engineHeatAmount < 93.8f)
        {
            WarningSt1.enabled = false;
            if (WarningSt1.GetComponent<Image>().enabled == true)
            {
                WarningSt1.GetComponent<Image>().enabled = false;
            }
            startedWarningSt1Blink = false;
        }
        if(playerEngine.engineHeatAmount < 81.1f)
        {
            WarningSt1.enabled = false;
            WarningSt2.SwitchOff();
        }
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void ResetScore()
    {
        gameScore = 0.0f;
    }

    public void StopScore()
    {

    }
}
