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
        EventManager.instance.CallEvent( MyEventType.StateQuestionScreenEnter, null);
        EventManager.instance.CallEvent(MyEventType.StartRound, null);

        EventManager.instance.RegisterListener(MyEventType.AnimQuestionPanelExitEnd, AnimationEnd);
    }

    public override void Update()
    {
        
    }

    public override void Exit() 
    {
        EventManager.instance.CallEvent(MyEventType.StateQuestionScreenExit, null);

        EventManager.instance.UnregisterListener(MyEventType.AnimAnswersPanelExitEnd, AnimationEnd);
    }

    void AnimationEnd( EventInfo info)
    {
        ChangeState(new AnswersScreenState(stateMachine));
    }
}

