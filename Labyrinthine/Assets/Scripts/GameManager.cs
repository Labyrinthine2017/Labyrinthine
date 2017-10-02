using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int combo2Score = 5, combo3Score = 12, combo4Score = 23;
    float gameScore { get; set; }
    public int comboScore { get; set; }
    int comboValue { get; set; }
    public bool controller { get; set; }

    Player player;
    Text scoreText, comboText, heatText;
    EngineBehaviour playerEngine;

	void Start ()
    {
        Application.targetFrameRate = 60;
        comboValue = 1;
        gameScore = 0;
	}

    void Awake()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        comboText = GameObject.FindGameObjectWithTag("ComboText").GetComponent<Text>();
        heatText = GameObject.FindGameObjectWithTag("EngineHeatText").GetComponent<Text>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerEngine = GameObject.FindGameObjectWithTag("Player").GetComponent<EngineBehaviour>();
    }

    void Update()
    {
        if(comboScore >= combo2Score)
        {
            comboValue = 2;
        }
        if(comboScore >= combo3Score)
        {
            comboValue = 3;
        }
        if (comboScore >= combo4Score)
        {
            comboValue = 4;
        }
    }
    void FixedUpdate()
    {
        //Runs UI Update once a frame
        UpdateUI();
    }

    public void AddScore(float a_score)
    {
        gameScore += a_score * comboValue;
        
    }
    public void SubtractScore(float a_score)
    {
        gameScore -= a_score;
    }
    public void ResetCombo()
    {
        comboValue = 1;
        comboScore = 0;
    }

    //Updates the UI element of the values for the player
    void UpdateUI()
    {
        scoreText.text = "Score: " + gameScore.ToString();
        comboText.text = "x" + comboValue.ToString();
        heatText.text = playerEngine.engineHeatAmount.ToString() + "%";
        
    }

}
