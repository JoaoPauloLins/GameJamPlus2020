using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameCalculator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textAnswer1;

    [SerializeField] private TextMeshProUGUI textAnswer2;

    [SerializeField] private TextMeshProUGUI textAnswer3;

    [SerializeField] private TextMeshProUGUI textQuestion;

    private bool isCorrect1;
    private bool isCorrect2;
    private bool isCorrect3;

    private MiniGameCalculatorData data;

    private Action OnChoosingAnswer;

    private Action OnOperationsFinished;

    private int numberOfOperations;

    private int currentOperationIndex;

    private Operation currentOperation;


    public void init(MiniGameCalculatorData data, Action OnChoosingAnswerHandler, Action OnOperationsFinishedHandler){
        this.currentOperationIndex = 0;
        this.data = data;
        currentOperation = data.getOperations()[this.currentOperationIndex];
        this.numberOfOperations = data.getCountMax();
        this.OnChoosingAnswer = OnChoosingAnswerHandler;
        this.OnOperationsFinished = OnOperationsFinishedHandler;
        this.textQuestion.text = currentOperation.question;
        for (int i = 0; i < currentOperation.quizTopic.Count; i++)
        {
            switch (i)
            {  
                case 0:
                    this.textAnswer1.text = currentOperation.quizTopic[i].answer;
                    this.isCorrect1 = currentOperation.quizTopic[i].isCorrect;
                    break;
                case 1:
                    this.textAnswer2.text = currentOperation.quizTopic[i].answer;
                    this.isCorrect2 = currentOperation.quizTopic[i].isCorrect;
                    break;
                case 2:
                    this.textAnswer3.text = currentOperation.quizTopic[i].answer;
                    this.isCorrect3 = currentOperation.quizTopic[i].isCorrect;
                    break;
            }
        }
    }
    public void chooseAnswer1(){

    }
    public void chooseAnswer2(){

    }
    public void chooseAnswer3(){

    }
}