using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Audio
{
    public string name;

    public AudioClip sound;

    [Range(0f, 1f)]
    public float volume;
    [Range(-1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float spatialBlend;

    public bool isLoop;

    [HideInInspector]
    public AudioSource source;
}