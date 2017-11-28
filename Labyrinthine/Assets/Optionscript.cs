using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Optionscript : MonoBehaviour
{


    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OptionPrompt()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
