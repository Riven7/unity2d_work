using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AdjustVolume : MonoBehaviour
{
    public Slider[] volumeSlider;
    public AudioMixer adMixer;
    //private AudioSource audio1;

    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0; //使游戏一加载进来就暂停，弹出菜单界面
        //audio1 = GetComponent<AudioSource>();
    }

    public void allVolume()
    {
        adMixer.SetFloat("MasterVolume", volumeSlider[0].value);
    }

    public void bkMusic()
    {
        adMixer.SetFloat("Music_bk", volumeSlider[1].value);
    }

    public void heroVolume()
    {
        adMixer.SetFloat("hero", volumeSlider[2].value);
    }

    public void propVolume()
    {
        adMixer.SetFloat("prop", volumeSlider[3].value);
    }

    public void boomVolume()
    {
        adMixer.SetFloat("boom", volumeSlider[4].value);
    }
}
