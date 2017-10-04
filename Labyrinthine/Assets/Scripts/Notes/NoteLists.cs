using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLists : MonoBehaviour
{
    Stack<Note> noteStack;
    List<Note> noteList;
    GameManager manager;
	// Use this for initialization
    void Awake()
    {
        noteStack = new Stack<Note>();
        noteList = new List<Note>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
	void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            noteList.Add(transform.GetChild(i).GetComponent<Note>());
        }
        Bubblesort(noteList);
        noteList.Reverse();
        foreach(Note note in noteList)
        {
            noteStack.Push(note);
        }
    }

    void Update()
    {
        if (noteStack.Count > 0)
        {
            Vector3 vecBetween = manager.GetPlayer().transform.position - noteStack.Peek().transform.position;
            Vector3 vecTowards = vecBetween.normalized;
            //Debug.Log("Note: " + noteList[0].transform.position.x + "   Player: " + manager.GetPlayer().transform.position.x);
            if (manager.GetPlayer().transform.position.x >= noteStack.Peek().transform.position.x - 0.3f && manager.GetPlayer().transform.position.x <= noteStack.Peek().transform.position.x + 0.3f)
            {
                Debug.Log(vecBetween.magnitude);
                if (vecBetween.magnitude <= 5.0f)
                {
                    noteStack.Peek().AllowedCollection(true);
                }
            }
            if (manager.GetPlayer().transform.position.z > noteStack.Peek().transform.position.z)
            {
                noteStack.Peek().AllowedCollection(false);
                noteStack.Pop();
            }
        }
    }

    public List<Note> GetNoteList()
    {
        return noteList;
    }

    public List<Note> Bubblesort(List<Note> a)
    {
        Note temp;
        for (int i = 1; i <= a.Count; i++)
        {
            for (int j = 0; j < a.Count - i; j++)
            {
                if (a[j].transform.position.z > a[j + 1].transform.position.z)
                {
                    temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                }
            }
            
        }
        return a;
    }
}
