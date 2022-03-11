using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public string soundName;
    [Space]
    public Sound[] sounds;

    public static AudioManager instance;
    

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)  
        {
            s.source = gameObject.AddComponent<AudioSource>();
            
            
           
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
            s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
        }  
    }

    void Start()
    {
    

        switch (SceneManager.GetActiveScene().name)
        {
            case "MainMenu":
                StopAllSound();
                PlaySound("MainMenuTheme");
                break;
            case "GameSetup":
                StopAllSound();
                PlaySound("EmptyRoom");
                break;
            case "Options":
                StopAllSound();
                PlaySound("Campfire");
                break;
            case "Gameplay":
                StopAllSound();
                PlaySound("GamePlayTheme");
                break;


            default:
                PlaySound("Broken");
                break;
            
        }
        
       
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            FadeOut("MainMenuTheme");
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log($"{s} cannot be found to play");
            
            return;
        }
        s.source.Play();
        Debug.Log($"I've Played {name} sound");
    }

    public void FadeIn(string sound)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == sound)
            {
                Debug.Log($"{sound} is fading in");
                s.volume += .4f * Time.deltaTime;
            }
        }
        
    }
    public void FadeOut(string sound)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == sound)
            {
                Debug.Log($"{sound} has is fading out");
                s.source.volume -= .4f * Time.deltaTime;
            }
        }
    }

    public void StopPlayingSound(string soundName)
    {
        Sound s = Array.Find(sounds, item => item.name == soundName);

        if (s == null)
        {
            Debug.LogWarning($"{s} cannot be found to play");
            return;
        }
        s.source.Stop ();
    }

    public void StopAllSound()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    public void ChangeGlobalVolume(float value)
    {
        AudioListener.volume = value;
    }


}
