using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    private float time;
    
    private void Start()
    {
        setTime(15);
    }

    private void setTimeText(float time){
        int intTime = (int)time;
        this.timeText.text = intTime.ToString();
    }

    private void Update()
    {
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

    private void setTime(float newTime) {
        this.time = newTime;
        setTimeText(this.time);
    }

    private void timeOut() {
        // Informar para o MiniGameController que o jogador perdeu o mini game atual
    }
}