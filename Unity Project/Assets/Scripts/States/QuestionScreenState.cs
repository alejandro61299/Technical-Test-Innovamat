using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionScreenState : State
{
    public QuestionScreenState(StateMachine stateMachine ) : base(stateMachine)
    {}
    public override void Enter() 
    {
        Managers.Gui.PlayAnimation("Question Panel", "Bounce");
        Managers.Game.PrepareNewRound();
    }
    public override void Exit() 
    {
        Managers.Gui.PlayAnimation("Question Panel", "None");
    }
    public override void Event(string name, object obj)
    {
        if (name.Equals("OnClickButton"))
        {
            ChangeState(new AnswersScreenState(stateMachine));
        }
        if (name.Equals("Animation Event"))
        {
            MyAnimationEvent e = (MyAnimationEvent)obj;

            if (e.gameObject.name.Equals("Question Panel") && e.name.Equals("End"))
            {
                ChangeState(new AnswersScreenState(stateMachine));
            }
        }
    }
}

