using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SoundManagerUI : MonoBehaviour
{
    public static SoundManagerUI Instance;

    // TODO:: If these arrays grow too much, look into dictionaries again.
    // Dictionaries are not serializable in Unity so they cannot be brought out to the inspector.
    // My attempt to do this manually gave an "object reference not set to an instance of an object" error that I could not figure out.
    [Serializable]
    public struct NamedAudioSource
    {
        public string name;
        public AudioSource audio;
    }

    public NamedAudioSource[] SoundAudioSources;
    public NamedAudioSource[] MusicAudioSources;

    private float musicVolume = 1.0f;
    private float soundVolume = 1.0f;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if(Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(string key)
    {
        foreach(var itr in SoundAudioSources) {
            if(itr.name.Equals(key)) {
                itr.audio.PlayOneShotSoundManaged(itr.audio.clip, soundVolume);
                return;
            }
        }

        Debug.Log($"Error! {key} not found int audio manager.");
    }

    public void PlayMusic(string key)
    {
        foreach(var itr in MusicAudioSources) {
            if(itr.name.Equals(key)) {
                itr.audio.PlayLoopingMusicManaged(musicVolume, 1.0f, true);
                return;
            }
        }

        Debug.Log($"Error! {key} not found int audio manager.");
    }

    public void SetStopSoundsOnLevelLoad(bool b)
    {
        SoundManager.StopSoundsOnLevelLoad = b;
    }
    public void SetMusicVolume(float newVolume)
    {
        Debug.Log(newVolume);

        SoundManager.MusicVolume = newVolume;
        this.musicVolume = newVolume;
    }

    public void SetSoundVolume(float newVolume)
    {
        SoundManager.SoundVolume = newVolume;
        this.soundVolume = newVolume;
    }
}
