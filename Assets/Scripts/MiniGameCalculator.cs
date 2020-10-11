using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameCalculator : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicAudioSource;

    [SerializeField]
    private AudioClip paperAudioClip;
    [SerializeField] private TextMeshProUGUI textAnswer1;

    [SerializeField] private TextMeshProUGUI textAnswer2;

    [SerializeField] private TextMeshProUGUI textAnswer3;

    [SerializeField] private TextMeshProUGUI textQuestion;

    private bool isCorrect1;
    private bool isCorrect2;
    private bool isCorrect3;

    private MiniGameCalculatorData data;

    private Action OnChoosingWrongAnswer;

    private Action OnChoosingRightAnswer;

    private int numberOfOperations;

    private int currentOperationIndex;

    private Operation currentOperation;

    private AudioSource audioSource;


    public void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void init(MiniGameCalculatorData data, Action OnChoosingRightAnswerHandler, Action OnChoosingWrongAnswerHandler){
        this.currentOperationIndex = 0;
        this.data = data;
        this.numberOfOperations = data.getCountMax();
        this.OnChoosingRightAnswer = OnChoosingRightAnswerHandler;
        this.OnChoosingWrongAnswer = OnChoosingWrongAnswerHandler;
        this.playMusic(data.getMusic());
        this.setupOperation();
    }

    private void playMusic(AudioClip music) {
        this.musicAudioSource.loop = true;
        this.musicAudioSource.clip = music;
        this.musicAudioSource.Play();
    }

    private void nextOperation() {
        this.currentOperationIndex += 1;
        this.OnChoosingRightAnswer?.Invoke();
        this.audioSource.PlayOneShot(this.paperAudioClip);
        if (this.currentOperationIndex >= this.numberOfOperations) {
            Destroy(this.gameObject);
        } else {
            this.setupOperation();
        }
    }

    private void setupOperation() {
        this.currentOperation = data.getOperations()[this.currentOperationIndex];
        this.setupQuestion();
        this.setupAnswers();
    }

    private void setupQuestion() {
        this.textQuestion.text = currentOperation.question;
    }

    private void setupAnswers() {
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

    private void verifyAnswer(bool isCorrect) {
        if (isCorrect) {
            this.nextOperation();
        } else {
            this.OnChoosingWrongAnswer?.Invoke();
            Destroy(this.gameObject);
        }
    }

    public void chooseAnswer1() {
        this.verifyAnswer(this.isCorrect1);
    }

    public void chooseAnswer2() {
        this.verifyAnswer(this.isCorrect2);
    }

    public void chooseAnswer3() {
        this.verifyAnswer(this.isCorrect3);
    }
}