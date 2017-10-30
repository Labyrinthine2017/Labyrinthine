using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLists : MonoBehaviour
{
    Stack<Note> noteStack;
    List<Note> noteList;
    GameManager manager;
    //[SerializeField] float distanceBetweenPlayerAndNode = 7.0f;
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
        if (manager.GetPlayer().transform.position.z > noteStack.Peek().transform.position.z)
        {
            if (noteStack.Peek().collected == false)
            {
                manager.ResetCombo();
            }
            noteStack.Peek().AllowedCollection(false);
            noteStack.Pop();
        }
        //}
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
