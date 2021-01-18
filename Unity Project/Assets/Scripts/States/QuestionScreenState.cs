using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEvents;

public class QuestionScreenState : State
{
    public QuestionScreenState(StateMachine stateMachine ) : base(stateMachine)
    {}
    public override void Enter() 
    {
        EventSystem.instance.CallEvent("QuestionScreenStateEnter", null);
        EventSystem.instance.RegisterListener("QuestionPanelExitAnimEnd", AnimationEnd);

    }
    public override void Exit() 
    {
        EventSystem.instance.CallEvent("QuestionScreenStateExit", null);
    }

    void AnimationEnd( EventInfo info)
    {
        ChangeState(new AnswersScreenState(stateMachine));
    }
}

