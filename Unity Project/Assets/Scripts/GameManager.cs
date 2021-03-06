﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyEvents;

public enum Language { Catalan, Spanish, English  }
public class GameManager : MonoBehaviour
{
    private static GameManager current;
    public static GameManager instance
    {
        get
        {
            if (current == null)
            {
                current = GameObject.FindObjectOfType<GameManager>();
            }
            return current;
        }
    }

    // Game Data ---------------------

    public Language language = Language.Catalan;

    public int maxAnswers = 3;

    public int maxErrors = 2;

    public NumbersTranslation numbersTranslation;

    [HideInInspector]  public int success { get; private set; }
    [HideInInspector]  public int failures { get; private set; }

    [HideInInspector] public  List<int> answersList;

    [HideInInspector]  public int correctAnswerIndex = 0;
    [HideInInspector] public StateMachine gameStateMachine { get; private set; }

    void Start()
    {
        gameStateMachine = GetComponent<StateMachine>();
        gameStateMachine.ChangeState(new QuestionScreenState(gameStateMachine), 1.5f);

        // Events Register 
        EventManager.instance.StartListening(MyEventType.StartRound, StratRound);
        EventManager.instance.StartListening(MyEventType.EndRound, EndRound);
    }

    public void StratRound( EventInfo ei)
    {
        GenerateRoundInfo();
;    }
    void EndRound( EventInfo ei)
    {
        RoundEmdEventInfo info = (RoundEmdEventInfo)ei;
        if ( info.playerWin )
        {
            ++success;
        }
        else
        {
            ++failures;
        }
    }
    public void GenerateRoundInfo()
    {
        // Choose Correct Answer & Set Question Number Text
        answersList.Clear();
        answersList = RandomEx.GetRandomNumbersList(maxAnswers);
        correctAnswerIndex = Random.Range(0, answersList.Count);
        EventManager.instance.TriggerEvent(MyEventType.RoundDataGenerated, null);
    }
    public void GetCorrectAnswer(out int number, out string name )
    {
        number = answersList[correctAnswerIndex];
        numbersTranslation.GetNumberName(number, language, out name);
    }
}
