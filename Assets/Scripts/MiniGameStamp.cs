using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameStamp : MonoBehaviour
{
    private MiniGameStampData data;
    private int currentNumbersOfPapers;

    private Action OnStamp;
    private Action OnPapersOff;

    public void init(MiniGameStampData data, Action OnStampHandler, Action OnPapersOffHandler) {
        this.data = data;
        // instanciar os sprites papéis
        this.currentNumbersOfPapers = data.getCountMax();
        this.OnStamp = OnStampHandler;
        this.OnPapersOff = OnPapersOffHandler;

    }

    public void stampPaper() {
        this.currentNumbersOfPapers -= 1;
        this.OnStamp?.Invoke();
        if (this.currentNumbersOfPapers <= 0) {
            OnPapersOff?.Invoke();
            Destroy(this);
        }
    }
}
