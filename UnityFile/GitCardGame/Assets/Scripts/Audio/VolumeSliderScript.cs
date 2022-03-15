using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderScript : MonoBehaviour
{   
    [SerializeField] private Slider _slider;
    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat("MyVolume", .5f);
        AudioManager.instance.ChangeGlobalVolume(PlayerPrefs.GetFloat("MyVolume", .2f));
        AudioManager.instance.ChangeGlobalVolume(_slider.value);
        _slider.onValueChanged.AddListener(val => AudioManager.instance.ChangeGlobalVolume(val));
        _slider.onValueChanged.AddListener(val => PlayerPrefs.SetFloat("MyVolume", val));
        
        
        
        
    }

    private void Update() 
    {
        
        
        PlayerPrefs.Save();
    }
}



/*
    TaroDev audiomanager video
    https://www.youtube.com/watch?v=tEsuLTpz_DU
*/
