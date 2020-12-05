using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionScreenState : State
{
    private Animator qPanel;
    public QuestionScreenState(StateMachine stateMachine ) : base(stateMachine)
    {}
    public override void Enter() 
    {
        qPanel = Managers.Gui.animators["Question Panel"];
        qPanel.gameObject.SetActive(true);
        qPanel.Play("Bounce");

        Managers.Game.PrepareNewRound();

    }
    public override void Exit() 
    {
        qPanel.Play("None");
        qPanel.gameObject.SetActive(false);
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

