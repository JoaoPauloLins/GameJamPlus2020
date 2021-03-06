﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    [SerializeField]
    private DayOfWorkData[] daysOfWork;

    [SerializeField]
    private GameObject miniGamesParent;

    [SerializeField]
    private TimeController timeController;

    [SerializeField]
    private CountController countController;

    [SerializeField]
    private InfoMiniGame infoMiniGame;

    [SerializeField]
    private Defeat defeat;

    [SerializeField]
    private Victory victory;

    [SerializeField]
    private MiniGameStamp miniGameStampPrefab;

    [SerializeField]
    private MiniGameCalculator miniGameCalculatorPrefab;

    [SerializeField]
    private MiniGameOrganize miniGameOrganizePrefab;

    private MiniGameData[] currentsTasks;
    private MiniGameData currentTask;

    private MiniGameEnum currentType;

    private int currentDay;
    private int currentTaskIndex;

    private void Start()
    {
        this.defeat.gameObject.SetActive(false);
        this.victory.gameObject.SetActive(false);
        this.currentDay = 0;
        this.currentTaskIndex = 0;
        this.currentsTasks = this.GetCurrentTasks();
        this.timeController.init(OnLose);
        this.countController.init(OnCountMax);
        this.infoMiniGame.init(OnInfoTimeOut);
        this.nextMiniGame();
    }

    private MiniGameData[] GetCurrentTasks() {
        if (this.daysOfWork.Length > 0 && this.currentDay < this.daysOfWork.Length) {
            return this.daysOfWork[this.currentDay].getTasks();
        } else {
            return null;
        }
    }

    private MiniGameData GetCurrentTask() {
        if (this.currentTaskIndex < this.currentsTasks.Length) {
            return this.currentsTasks[this.currentTaskIndex];
        } else {
            return null;
        }
    }

    private void nextMiniGame() {
        this.currentTask = this.GetCurrentTask();
        if (this.currentTask != null) {
            this.currentType = this.currentTask.getType();
            switch (this.currentType)
            {
                case MiniGameEnum.ORGANIZE:
                    this.infoMiniGame.setMiniGameInfo("ORGANIZE", "Your desk is a mess! Put each object in the box with the same object's color!!");
                    break;
                case MiniGameEnum.STAMP:
                    this.infoMiniGame.setMiniGameInfo("STAMP", "Stamp all the documents before the time runs out!!");
                    break;
                case MiniGameEnum.CALCULATE:
                    this.infoMiniGame.setMiniGameInfo("CALCULATE", "Your calculator is broken! Chose the correct answer according to the operation on your calculator!");
                    break;
                case MiniGameEnum.REST:
                    break;
            }
            this.showInfoMiniGame();
            this.infoMiniGame.startInfoMiniGame();
        } else {
            this.timeController.stopTimer();
            this.victory.gameObject.SetActive(true);
        }
    }

    private void initMiniGame() {
        switch (this.currentType)
        {
            case MiniGameEnum.ORGANIZE:
                MiniGameOrganize newMiniGameOrganize = Instantiate<MiniGameOrganize>(this.miniGameOrganizePrefab, this.miniGamesParent.transform);
                newMiniGameOrganize.init(this.currentTask as MiniGameOrganizeData, OnCountIncrease);
                break;
            case MiniGameEnum.STAMP:
                MiniGameStamp newMiniGameStamp = Instantiate<MiniGameStamp>(this.miniGameStampPrefab, this.miniGamesParent.transform);
                newMiniGameStamp.init(this.currentTask as MiniGameStampData, OnCountIncrease);
                break;
            case MiniGameEnum.CALCULATE:
                MiniGameCalculator newMiniGameCalculator = Instantiate<MiniGameCalculator>(this.miniGameCalculatorPrefab, this.miniGamesParent.transform);
                newMiniGameCalculator.init(this.currentTask as MiniGameCalculatorData, OnCountIncrease, OnLose);
                break;
            case MiniGameEnum.REST:
                break;
        }

        this.timeController.setTime(this.currentTask.getDuration());
        this.countController.StartCount(this.currentTask.getCountMax());
    }

    private void OnCountIncrease() {
        this.countController.SetCountText();
    }

    private void OnCountMax() {
        this.timeController.stopTimer();
        this.currentTaskIndex += 1;
        this.nextMiniGame();
    }

    private void OnLose() {
        foreach (Transform children in this.miniGamesParent.transform)
        {
            Destroy(children.gameObject);
        }
        this.timeController.stopTimer();
        this.defeat.gameObject.SetActive(true);
    }

    private void OnInfoTimeOut() {
        this.hideInfoMiniGame();
        this.initMiniGame();
    }

    private void showInfoMiniGame() {
        this.infoMiniGame.gameObject.SetActive(true);
    }

    private void hideInfoMiniGame() {
        this.infoMiniGame.gameObject.SetActive(false);
    }
}
