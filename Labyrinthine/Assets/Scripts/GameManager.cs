using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int combo2Score = 5, combo3Score = 12, combo4Score = 19;
    float gameScore { get; set; }
    public int comboScore { get; set; }
    int combo { get; set; }
    public bool controller { get; set; }

    GameObject player;
	// Use this for initialization
	void Start ()
    {
        Application.targetFrameRate = 60;
        combo = 1;
        gameScore = 0;
	}

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<PlayerMovement>().hasController;
    }

    void Update()
    {
        //Debug.Log(gameScore);
        if(comboScore >= combo2Score)
        {
            combo = 2;
        }
        if(comboScore >= combo3Score)
        {
            combo = 3;
        }
        if (comboScore >= combo4Score)
        {
            combo = 4;
        }
    }
    public void AddScore(float a_score)
    {
        gameScore += a_score * combo;
    }
    public void SubtractScore(float a_score)
    {
        gameScore -= a_score;
    }
    public void ResetCombo()
    {
        combo = 1;
        comboScore = 0;
    }

}
