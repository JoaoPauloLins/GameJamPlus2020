using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiniGameOrganize", menuName = "MiniGame/Organize", order = 2)]
public class MiniGameOrganizeData : MiniGameData
{
    public int penQtd;
    public int clipQtd;
    public int postItQtd;

    public override MiniGameEnum getType(){
        return this.type;
    }
}
