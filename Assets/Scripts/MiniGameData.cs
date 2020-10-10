using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameData : ScriptableObject
{
    [SerializeField]
    private float duration;

    private MiniGameEnum type;

    public float getDuration() {
        return this.duration;
    }

    public virtual MiniGameEnum getType() {
        return this.type;
    }
}
