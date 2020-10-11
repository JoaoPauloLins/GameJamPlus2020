using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameData : ScriptableObject
{
    [SerializeField]
    private AudioClip music;

    [SerializeField]
    private float duration;

    [SerializeField]
    private int countMax;

    [SerializeField]
    protected MiniGameEnum type;

    public float getDuration() {
        return this.duration;
    }

    public int getCountMax() {
        return this.countMax;
    }

    public AudioClip getMusic() {
        return this.music;
    }

    public virtual MiniGameEnum getType() {
        return this.type;
    }
}
