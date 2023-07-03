using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;



public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public Sound[] musicSound;
    public AudioSource musicSource;

    

    //private float currentVolume = 0.3f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    private void Start()
    {

        


        PlayMusic("Main");
    }

    
    


    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSound, x => x.name == name);  
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;

        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    
}
