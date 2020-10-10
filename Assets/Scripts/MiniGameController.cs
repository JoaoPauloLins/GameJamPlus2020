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
    private MiniGameStamp miniGameStamp;

    private MiniGameData[] currentsTasks;
    private MiniGameData currentTask;

    private int currentDay;
    private int currentTaskIndex;

    private void Start()
    {
        this.currentDay = 0;
        this.currentTaskIndex = 0;
        this.currentsTasks = this.GetCurrentTasks();
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
        MiniGameEnum currentType = this.currentTask.getType();
        switch (currentType)
        {
            case MiniGameEnum.ORGANIZE:
                break;
            case MiniGameEnum.STAMP:
                MiniGameStamp newMiniGameStamp = Instantiate<MiniGameStamp>(this.miniGameStamp, this.miniGamesParent.transform);
                newMiniGameStamp.init(this.currentTask as MiniGameStampData);
                break;
            case MiniGameEnum.CALCULATE:
                break;
            case MiniGameEnum.REST:
                break;
        }
    }
}
