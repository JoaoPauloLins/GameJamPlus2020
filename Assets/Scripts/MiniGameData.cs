﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameData : ScriptableObject
{
    [SerializeField]
    private float duration;

    public float getDuration() {
        return this.duration;
    }
}