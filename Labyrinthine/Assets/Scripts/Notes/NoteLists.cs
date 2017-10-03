using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLists : MonoBehaviour
{
    List<Note> noteList;
	// Use this for initialization
    void Awake()
    {
        noteList = new List<Note>();
    }
	void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            noteList.Add(transform.GetChild(i).GetComponent<Note>());
        }
        Bubblesort(noteList);
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
                if (a[j].transform.position.x > a[j + 1].transform.position.x)
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
