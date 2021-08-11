using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    public Sound[] sounds;

    private void Awake() {

        if(instance == null) {

            instance = this;

        }

        foreach(Sound s in sounds) {

            s.src = gameObject.AddComponent<AudioSource>();

            s.src.playOnAwake = s.playOnAwake;

            s.src.clip = s.clip;
            s.src.volume = s.volume;
            s.src.pitch = s.pitch;

        }

    }

    public void Play(string name) {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s != null) {

            s.src.Play();

        } else {

            Debug.LogError("Could not find Sound: " + name);

        }

    }

}

[System.Serializable]
public class Sound {

    public string name;

    public AudioClip clip;

    public bool playOnAwake;

    [Range(0, 1)]
    public float volume = 0.5f;
    [Range(0.1f, 3)]
    public float pitch = 1;

    [HideInInspector]
    public AudioSource src;

}