using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DayOfWork", menuName = "DayOfWork", order = 2)]
public class DayOfWorkData : ScriptableObject
{
    [SerializeField]
    private MiniGameData[] tasks;

    public MiniGameData[] getTasks() {
        return this.tasks;
    }
}
