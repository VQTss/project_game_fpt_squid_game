﻿using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public Sounds[] sounds;
    public float timer;
    public bool still_pitch;
    private void Awake()
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

        foreach (Sounds s in sounds)
        {
            s.audio = gameObject.AddComponent<AudioSource>();
            s.audio.clip = s.clip;
            s.audio.playOnAwake = false;
            s.audio.volume = s.volume;
            s.audio.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        Sounds snd = Array.Find(sounds, s => s.name == name);
        if (snd == null)
            return;

        if (still_pitch && name == "collect_cube")
        {
            timer = 0f;
            snd.audio.pitch += .01f;
        }

        else if (!still_pitch && name == "collect_cube")
        {
            snd.audio.pitch = 1f;
            still_pitch = true;
        }
        snd.audio.Play();
    }

    public void stop(string name)
    {
        Sounds snd = Array.Find(sounds, s => s.name == name);
        if (snd == null)
            return;


        snd.audio.Stop();
    }

    

    public void Update()
    {
        if (timer <= 1f && still_pitch)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            still_pitch = false;
        }

        if (Time.timeScale == 0)
        {
            Sounds snd = Array.Find(sounds, s => s.name == "enem");
            if (snd == null)
                return;


            snd.audio.Pause();
        }

    }


    public void sPlay(string name, float pitch)
    {
        Sounds snd = Array.Find(sounds, s => s.name == name);
        if (snd == null)
            return;

        snd.audio.pitch = pitch;
        snd.audio.Play();
    }
}
