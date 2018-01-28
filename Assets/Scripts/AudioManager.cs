using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] fx;
    private float currentSoundVolume=1;
    private float currentFxVolume=1;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
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
        }

        foreach (Sound s in fx)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }


    public void Mute()
    {
        foreach (Sound s in sounds)
        {
           s.source.volume = 0;            
        }
        foreach (Sound s in fx)
        {
            s.source.volume = 0;
        }
    }

    public void PlaySound(string name)
    {

        StopAllSounds();
        Sound s = Array.Find(sounds, sound => sound.name == name);
       
        if (s==null)
        {
            return;
        }

        s.source.Play();
    }

    public void PlayFx(string name)
    {
        Sound s = Array.Find(fx, fx => fx.name == name);

        if (s == null)
        {
            return;
        }
        s.source.Play();
    }
    public bool IsPlayingSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return false;
        }
        return s.source.isPlaying;
    }
    public bool IsPlayingFx(string name)
    {
        Sound s = Array.Find(fx, fx => fx.name == name);

        if (s == null)
        {
            return false;
        }
        return s.source.isPlaying;
    }
    public void StopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
        foreach (Sound s in fx)
        {
            s.source.Stop();
        }
    }

    public void SetVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.volume = volume;
    }

    public void AdjustMainVolumeSounds(float volume)
    {
        currentSoundVolume = volume;
        foreach (Sound s in sounds)
        {
            s.source.volume = volume;
        }
    }

    public void AdjustMainVolumeFx(float volume)
    {
        currentFxVolume = volume;
        foreach (Sound s in fx)
        {
            s.source.volume = volume;
        }
    }

    public float GetMainVolume()
    {
        return currentSoundVolume;
    }
    public float GetFxVolume()
    {
        return currentFxVolume;
    }
}
