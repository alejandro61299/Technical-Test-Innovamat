using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEvents;

public class QuestionScreenState : State
{
    Timer timer;
    public QuestionScreenState(StateMachine stateMachine ) : base(stateMachine)
    {}
    public override void Enter() 
    {
        EventManager.instance.StartListening(MyEventType.AnimQuestionPanelExitEnd, GoNextState);

        EventManager.instance.TriggerEvent( MyEventType.StateQuestionScreenEnter, null);
        EventManager.instance.TriggerEvent(MyEventType.StartRound, null);

    }

    public override void Update()
    {
        
    }

    public override void Exit() 
    {
        EventManager.instance.StopListening(MyEventType.AnimAnswersPanelExitEnd, GoNextState);

        EventManager.instance.TriggerEvent(MyEventType.StateQuestionScreenExit, null);
    }

    void GoNextState( EventInfo info)
    {
        ChangeState(new AnswersScreenState(stateMachine));
    }
}

