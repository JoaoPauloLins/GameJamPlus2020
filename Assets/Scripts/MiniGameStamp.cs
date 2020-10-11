using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameStamp : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicAudioSource;
    
    private MiniGameStampData data;
    private int currentNumbersOfPapers;

    private AudioSource sfxAudioSource;

    private Action OnStamp;

    private void Start()
    {
        this.sfxAudioSource = GetComponent<AudioSource>();
    }

    public void init(MiniGameStampData data, Action OnStampHandler) {
        this.data = data;
        this.currentNumbersOfPapers = data.getCountMax();
        this.OnStamp = OnStampHandler;
        this.playMusic(data.getMusic());
    }

    public void stampPaper() {
        this.currentNumbersOfPapers -= 1;
        this.OnStamp?.Invoke();
        this.sfxAudioSource.Play();
        if (this.currentNumbersOfPapers <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void playMusic(AudioClip music) {
        this.musicAudioSource.loop = true;
        this.musicAudioSource.clip = music;
        this.musicAudioSource.Play();
    }
}
