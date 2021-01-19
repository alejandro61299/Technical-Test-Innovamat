using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyEvents;

public class AnswersScreenState : State
{
    int currentErrors = 0;

    public AnswersScreenState(StateMachine stateMachine) : base(stateMachine)
    { }
    public override void Enter()
    {
        EventManager.instance.StartListening(MyEventType.AnimAnswersPanelExitEnd, GoNextState);
        EventManager.instance.StartListening(MyEventType.CorrectButtonClicked, CorrectButtonclicked);
        EventManager.instance.StartListening(MyEventType.InorrectButtonClicked, IncorrectButtonClicked);
        EventManager.instance.TriggerEvent(MyEventType.StateAnswersScreenEnter, null);

    }

    public override void Exit()
    {
        EventManager.instance.StopListening(MyEventType.AnimAnswersPanelExitEnd, GoNextState);
        EventManager.instance.StopListening(MyEventType.CorrectButtonClicked, CorrectButtonclicked);
        EventManager.instance.StopListening(MyEventType.InorrectButtonClicked, IncorrectButtonClicked);
        EventManager.instance.TriggerEvent(MyEventType.StateAnswersScreenExit, null);
    }

    void GoNextState( EventInfo info )
    {
        ChangeState(new QuestionScreenState(stateMachine));
    }

    void CorrectButtonclicked(EventInfo info)
    {
        RoundEmdEventInfo roundInfo = new RoundEmdEventInfo();
        roundInfo.playerWin = true;
        EventManager.instance.TriggerEvent(MyEventType.EndRound, roundInfo);

    }

    void IncorrectButtonClicked(EventInfo info)
    {
        ++currentErrors;

        if (currentErrors == GameManager.instance.maxErrors)
        {
            RoundEmdEventInfo roundInfo = new RoundEmdEventInfo();
            roundInfo.playerWin = false;
            EventManager.instance.TriggerEvent(MyEventType.EndRound, roundInfo);
        }
    }
}
