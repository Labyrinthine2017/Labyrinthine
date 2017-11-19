using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicVolume : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider sliderVolume;

    public void ControlVolume()
    {
        
        sliderVolume.value = audioSource.volume;
    }
}
