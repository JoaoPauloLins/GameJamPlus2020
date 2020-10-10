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
        
    }

    private void Update()
    {
        
    }

    private void setTime(float newTime) {
        this.time = newTime;
    }

    private void timeOut() {
        // Informar para o MiniGameController que o jogador perdeu o mini game atual
    }
}
