﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameOrganize : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private OrganizeItem clipPrefab;
    [SerializeField] private OrganizeItem postItPrefab;
    [SerializeField] private OrganizeItem penPrefab;
    [SerializeField] private RectTransform boxBlue;
    [SerializeField] private RectTransform boxPurple;
    [SerializeField] private RectTransform boxRed;
    [SerializeField] private Transform itemAreaTransform;
    [SerializeField] private RectTransform itemAreaRectTransform;

    private MiniGameOrganizeData data;

    private Action OnItemOrganized;

    

    private int itemsOrganized;

    

    public void init(MiniGameOrganizeData data, Action OnItemOrganizedHandler) {
        this.data = data;
        this.itemsOrganized = 0;
        this.OnItemOrganized = OnItemOrganizedHandler;
        this.playMusic(data.getMusic());
        this.instantiateItems();
    }

    private void playMusic(AudioClip music) {
        this.musicAudioSource.loop = true;
        this.musicAudioSource.clip = music;
        this.musicAudioSource.Play();
    }

    private void instantiateItems() {
        for (int i = 0; i < data.penQtd; i++)
        {
            OrganizeItem newPen = Instantiate<OrganizeItem>(this.penPrefab, this.itemAreaTransform);
            newPen.init(boxRed, OnCorrectItemPosition);
            float randomPosX = UnityEngine.Random.Range(-250,250);
            float randomPosY = UnityEngine.Random.Range(-180,180);
            newPen.setPosition(new Vector2(randomPosX, randomPosY));
        }

        for (int i = 0; i < data.clipQtd; i++)
        {
            OrganizeItem newClip = Instantiate<OrganizeItem>(this.clipPrefab, this.itemAreaTransform);
            newClip.init(boxBlue, OnCorrectItemPosition);
            float randomPosX = UnityEngine.Random.Range(-250,250);
            float randomPosY = UnityEngine.Random.Range(-180,180);
            newClip.setPosition(new Vector2(randomPosX, randomPosY));
        }

        for (int i = 0; i < data.postItQtd; i++)
        {
            OrganizeItem newPostIt = Instantiate<OrganizeItem>(this.postItPrefab, this.itemAreaTransform);
            newPostIt.init(boxPurple, OnCorrectItemPosition);
            float randomPosX = UnityEngine.Random.Range(-250,250);
            float randomPosY = UnityEngine.Random.Range(-180,180);
            newPostIt.setPosition(new Vector2(randomPosX, randomPosY));
        }
    }

    private void OnCorrectItemPosition() {
        OnItemOrganized?.Invoke();
        this.itemsOrganized++;
        if (this.itemsOrganized >= this.data.getCountMax()) {
            Destroy(this.gameObject);
        }
    }
}
