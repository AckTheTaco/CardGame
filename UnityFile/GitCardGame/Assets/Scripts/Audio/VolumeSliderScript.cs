using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderScript : MonoBehaviour
{   
    [SerializeField] private Slider _slider;
    void Start()
    {
        AudioManager.instance.ChangeGlobalVolume(_slider.value);
        _slider.onValueChanged.AddListener(val => AudioManager.instance.ChangeGlobalVolume(val));
    }
}



/*
    TaroDev audiomanager video
    https://www.youtube.com/watch?v=tEsuLTpz_DU
*/
