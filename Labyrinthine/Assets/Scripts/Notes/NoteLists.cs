using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLists : MonoBehaviour
{
    private Stack<Note> noteStack = new Stack<Note>();
    private List<Note> noteList = new List<Note>();
    private GameManager manager;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
	void Start()
    {
        //Gets and adds all children to the List
        for (int i = 0; i < transform.childCount; i++)
        {
            noteList.Add(transform.GetChild(i).GetComponent<Note>());
        }
        //Sorts the list
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
            if (noteStack.Peek().IsCollected == false)
            {
                manager.ResetCombo();
            }
            noteStack.Pop();
        }
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
