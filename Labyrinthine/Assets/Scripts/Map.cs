using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<GameObject> notes { get; set; }
	// Use this for initialization
	void Start ()
    {
        notes.AddRange(GameObject.FindGameObjectsWithTag("Note"));
	}
}
