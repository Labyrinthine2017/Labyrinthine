using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{

    public Animator anim;
    public float animSpeed;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(Setbooooool("Left"));
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(Setbooooool("Right"));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Setbooooool("Jump"));
        }

        if (!anim.GetBool("Left") && !anim.GetBool("Right") && !anim.GetBool("Jump"))
        {
            anim.speed = 1;
        }
        else
        {
            anim.speed = animSpeed;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StartCoroutine(Setbooooool("Right"));
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            StartCoroutine(Setbooooool("Left"));
        }

    }


    IEnumerator Setbooooool(string boolName)
    {
        anim.SetBool(boolName, true);
        yield return new WaitForSecondsRealtime(0.01f);
        anim.SetBool(boolName, false);

    }
}
