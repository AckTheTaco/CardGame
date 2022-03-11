using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Space]
    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;

    public float volumeVariance;

    public float pitchVariance;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
