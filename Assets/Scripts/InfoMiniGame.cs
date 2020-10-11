using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoMiniGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI miniGameName;
    [SerializeField] private TextMeshProUGUI miniGameDescription;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float maxTime;

    private Action OnTimeOut;
    private float time;

    private bool infoStarted;

    public void init(Action OnTimeOutHandler) {
        this.OnTimeOut = OnTimeOutHandler;
    }

    public void setMiniGameInfo(string name, string description) {
        this.miniGameName.text = name;
        this.miniGameDescription.text = description;
    }

    public void startInfoMiniGame() {
        this.time = this.maxTime;
        this.setTimeText(this.maxTime);
        this.startTimer();
    }

    private void setTimeText(float time){
        int intTime = (int)time;
        this.timeText.text = intTime.ToString();
    }

    private void Update()
    {
        if (this.infoStarted) {
            if(this.time > 0)
            {
                this.time -= Time.deltaTime;
                setTimeText(this.time);
            }
            else
            {
                timeOut();
            }
        }
    }

    private void timeOut() {
        this.stopTimer();
        this.OnTimeOut?.Invoke();
    }

    private void startTimer() {
        this.infoStarted = true;
    }

    private void stopTimer() {
        this.infoStarted = false;
    }
}
