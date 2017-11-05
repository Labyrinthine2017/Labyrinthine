using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatMenu : MonoBehaviour
{
    private Vector3 vCurrentPos;
    private Vector3 vStartPos;
    private Vector3 vEndPos;

	void Awake ()
    {
        vCurrentPos = this.gameObject.transform.position;

        vStartPos = new Vector3(0, 0.38f, 899.97f);
        vEndPos = new Vector3(0, 0.38f, -48.3f);
    }
	
	void Update ()
    {
        if(vCurrentPos == vEndPos)
            vCurrentPos = vStartPos;
	}
}
