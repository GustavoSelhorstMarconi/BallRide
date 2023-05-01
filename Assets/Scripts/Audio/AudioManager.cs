using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Audio[] audios;

    public static AudioManager instance;

    public void Start()
    {
        if (PlayerPrefs.GetString("Difficulty", "Normal") == "Normal")
        {
            PlaySound("ThemeSong");
        }
        else
        {
            PlaySound("ThemeSongSpeedMode");
        }
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Audio audio in audios)
        {
            audio.source = gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.sound;

            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;
            audio.source.loop = audio.isLoop;
            audio.source.spatialBlend = audio.spatialBlend;
        }
    }

    public void PlaySound(string name)
    {
        Audio audio = Array.Find(audios, audio => audio.name == name);
        if (audio == null)
        {
            return;
        }
        audio.source.Play();
    }

    public void StopSound(string name)
    {
        Audio audio = Array.Find(audios, audio => audio.name == name);
        if (audio == null)
        {
            return;
        }
        audio.source.Stop();
    }
}