using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiniGameStamp", menuName = "MiniGame/Stamp", order = 1)]
public class MiniGameStampData : MiniGameData
{
    public override MiniGameEnum getType() {
        return this.type;
    }
}
