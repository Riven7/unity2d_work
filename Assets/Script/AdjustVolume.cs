using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AdjustVolume : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer adMixer;
    //private AudioSource audio1;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
        //audio1 = GetComponent<AudioSource>();
    }

    public void turnVolume()
    {
        adMixer.SetFloat("MasterVolume", volumeSlider.value);
    }
}
