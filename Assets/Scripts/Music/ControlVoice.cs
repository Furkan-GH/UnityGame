using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVoice : MonoBehaviour
{
    public Slider musicSlider;

    

    private void Start()
    {

        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        musicSlider.value = savedVolume;
        MusicManager.Instance.MusicVolume(savedVolume);

    }

    


    public void MusicVolume()
    {
        MusicManager.Instance.MusicVolume(musicSlider.value);
    }
}
