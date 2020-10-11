using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameStamp : MonoBehaviour
{
    private MiniGameStampData data;
    private int currentNumbersOfPapers;

    private AudioSource audioSource;

    private Action OnStamp;

    private void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void init(MiniGameStampData data, Action OnStampHandler) {
        this.data = data;
        // instanciar os sprites papéis
        this.currentNumbersOfPapers = data.getCountMax();
        this.OnStamp = OnStampHandler;
    }

    public void stampPaper() {
        this.currentNumbersOfPapers -= 1;
        this.OnStamp?.Invoke();
        this.audioSource.Play();
        if (this.currentNumbersOfPapers <= 0) {
            Destroy(this.gameObject);
        }
    }
}
