using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiniGameStamp", menuName = "MiniGame/Stamp", order = 1)]
public class MiniGameStampData : MiniGameData
{
    [SerializeField]
    private int numbersOfPapers;

    [SerializeField]
    private MiniGameEnum type =  MiniGameEnum.STAMP;

    public int getNumberOfPapers() {
        return this.numbersOfPapers;
    }

    public override MiniGameEnum getType() {
        return this.type;
    }
}
