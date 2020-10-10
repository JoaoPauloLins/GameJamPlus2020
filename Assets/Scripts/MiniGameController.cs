using System.Collections;
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
    private MiniGameStamp miniGameStampPrefab;

    private MiniGameData[] currentsTasks;
    private MiniGameData currentTask;

    private int currentDay;
    private int currentTaskIndex;

    private void Start()
    {
        this.currentDay = 0;
        this.currentTaskIndex = 0;
        this.currentsTasks = this.GetCurrentTasks();
        this.timeController.init(OnTimeOut);
        this.countController.init(OnCountMax);
        this.initMiniGame();
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

    private void initMiniGame() {
        this.currentTask = this.GetCurrentTask();
        if (this.currentTask != null) {
            MiniGameEnum currentType = this.currentTask.getType();
            switch (currentType)
            {
                case MiniGameEnum.ORGANIZE:
                    break;
                case MiniGameEnum.STAMP:
                    MiniGameStamp newMiniGameStamp = Instantiate<MiniGameStamp>(this.miniGameStampPrefab, this.miniGamesParent.transform);
                    newMiniGameStamp.init(this.currentTask as MiniGameStampData, OnCountIncrease, OnStampPapersOff);
                    break;
                case MiniGameEnum.CALCULATE:
                    break;
                case MiniGameEnum.REST:
                    break;
            }

            this.timeController.setTime(this.currentTask.getDuration());
            this.countController.StartCount(this.currentTask.getCountMax());
        } else {
            // TELA DE VITÓRIA!!
            Debug.Log("VOCÊ TERMINOU TODAS AS TASKS DO DIA!!!!!!!");
        }
    }

    private void OnTimeOut() {
        Debug.Log("ACABOU O TEMPO!!!!!!!");
    }

    private void OnCountIncrease() {
        this.countController.SetCountText();
    }

    private void OnCountMax() {
        this.currentTaskIndex += 1;
        this.initMiniGame();
    }

    private void OnStampPapersOff() {
        Debug.Log("ACABOU OS PAPEIS");
    }
}
