using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    private Action OnTimeOut;

    private float time;
    private bool gameStarted;

    private void setTimeText(float time){
        int intTime = (int)time;
        this.timeText.text = intTime.ToString();
    }

    private void Update()
    {
        if (this.gameStarted) {
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
        this.OnTimeOut?.Invoke();
        this.gameStarted = false;
    }

    public void init(Action OnTimeOutHandler) {
        this.OnTimeOut = OnTimeOutHandler;
    }

    public void setTime(float newTime) {
        this.time = newTime;
        setTimeText(this.time);
        this.gameStarted = true;
    }

    public void stopTimer() {
        this.gameStarted = false;
    }
}