// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    
    public AudioSource EffectSource;
    public AudioSource MusicSource;
    public AudioSource VFXSource;

    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    public static SoundManager Instance = null;

    public AudioClip dart_Hit;
    public AudioClip dart_Throw;
    public AudioClip dart_Destroy;
    public AudioClip dart_Reload;
    public AudioClip object_placed;
    public AudioClip plane_Scanning;
    public AudioClip dart_GameBackMusic;
    public AudioClip dart_DoubleScoreSound;
    public AudioClip dart_TripleScoreSound;
    public AudioClip power_selectedSound;
    public AudioClip power_PerfectSelectedSound;
    public AudioClip game_NewRecordMadeSound;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        play_dartbackMusic();
    }

    public void Play(AudioClip clip)
    {
        if (clip)
        {
            EffectSource.clip = clip;
            EffectSource.Play();
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip)
        {
        MusicSource.clip = clip;
        MusicSource.Play();
        }
    }

    public void PlayVFX(AudioClip clip)
    {
        if (clip)
        {
        VFXSource.clip = clip;
        VFXSource.Play();
        }
    }

    // public void RandomSoundEffect(params AudioClip[] clips)
    // {
    //     int randomIndex = Random.Range(0, clips.Length);
    //     float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

    //     EffectSource.pitch = randomPitch;
    //     EffectSource.clip = clips[randomIndex];
    //     EffectSource.Play();
    // }

    public void play_ObjectPlacedSound()
    {
        Play(object_placed);
    }

    public void play_dartHitSound()
    {
        Play(dart_Hit);
    }

    public void play_dartThrowSound()
    {
        Play(dart_Throw);
    }

    public void play_dartDestroySound()
    {
        Play(dart_Destroy);
    }

    public void play_dartReloadSound()
    {
        Play(dart_Reload);
    }

    public void play_dartbackMusic()
    {
        Play(dart_GameBackMusic);
    }
    
    public void play_DoubleScoreSound()
    {
        Play(dart_DoubleScoreSound);
    }
    
    public void play_TripleScoreSound()
    {
        PlayVFX(dart_TripleScoreSound);
    }

    public void play_PowerSelectedSound()
    {
        PlayVFX(power_selectedSound);
    }
    public void play_PowerPerfectSelectedSound()
    {
        PlayVFX(power_PerfectSelectedSound);
    }
    public void play_NewRecordMadeSound()
    {
        PlayVFX(game_NewRecordMadeSound);
    }


    }