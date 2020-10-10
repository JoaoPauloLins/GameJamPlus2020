using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MiniGameCalculator", menuName = "MiniGame/Calculator", order = 0)]
public class MiniGameCalculatorData : MiniGameData
{
    [SerializeField]
    private List<Operation> operations;

    public override MiniGameEnum getType(){
        return this.type;
    }
    public List<Operation> getOperations(){
        return this.operations;
    }
}
[Serializable]
public class Operation{
    public string question;
    public List<quizTopic> quizTopic;
}
[Serializable]
public class quizTopic{
    public string answer;
    public bool isCorrect;
}