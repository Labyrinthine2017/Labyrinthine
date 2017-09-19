using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject playerObject { get; set; }
    Player playerScript { get; set; }
    GameObject map { get; set; }
    // Use this for initialization
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerObject.GetComponent<Player>();
        map = GameObject.FindGameObjectWithTag("Note_Map");
    }
}

