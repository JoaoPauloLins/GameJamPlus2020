using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameStamp : MonoBehaviour
{
    private MiniGameStampData data;

    private int currentNumbersOfPapers;

    private void init(MiniGameStampData data) {
        this.data = data;
        // instanciar os sprites papéis
        this.currentNumbersOfPapers = data.getNumberOfPapers();
    }

    public void stampPaper() {
        this.currentNumbersOfPapers -= 1;
        if (this.currentNumbersOfPapers <= 0) {
            // Informar para o MiniGameController que o jogador venceu
        }
    }
}
