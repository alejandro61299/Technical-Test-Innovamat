using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyEvents;

public class AnswersScreenState : State
{
    private int maxErrors;
    private int currentErrors;
    private bool activeInput = false;

    public AnswersScreenState(StateMachine stateMachine) : base(stateMachine)
    { }
    public override void Enter()
    {
        currentErrors = 0;
        maxErrors = 2;
        
        EventManager.instance.CallEvent(MyEventType.StateAnswersScreenEnter, null);
        EventManager.instance.RegisterListener(MyEventType.AnimQuestionPanelExitEnd, AnimationEnd);
    }
    public override void Update()
    {
        //bool isIdle = Managers.Gui.animatedElements["Answers Panel"].IsStateName("Idle");

        //if (activeInput != isIdle)
        //{
        //    activeInput = isIdle;
        //    Managers.Game.answersManager.ButtonsInteraction(activeInput);
        //}
    }

    public override void Exit()
    {
        EventManager.instance.CallEvent(MyEventType.StateAnswersScreenExit, null);
    }

    void AnimationEnd( EventInfo info )
    {
        ChangeState(new QuestionScreenState(stateMachine));
    }


    public override void Event(string name, object obj)
    {
        //if (name.Equals("OnClickButton"))
        //{
        //    Color color;
        //    bool roundFinished = false;
        //    ButtonGuiElement clickedButton = (ButtonGuiElement)obj;

        //    if (Managers.Game.correctButton == clickedButton.button)
        //    {
        //        color = Managers.Gui.successColor;

                

        //        Managers.Gui.PlayAnimation("Answers Panel", "Idle To Out");
        //        //Managers.Game.AddScorePoint(false);  
        //        EventSystem.instance.CallEvent("Player Fails", null);
        //        roundFinished = true;
        //    }
        //    else
        //    {
        //        color = Managers.Gui.failureColor;
        //        Managers.Gui.PlayAnimation(clickedButton.name, "Out");
        //        ++currentErrors;

        //        if (currentErrors == maxErrors)
        //        {
        //            Managers.Gui.PlayAnimation("Answers Panel", "Idle To Out");
        //            Managers.Game.AddScorePoint(true);
        //            roundFinished = true;
        //        }
        //    }

        //    if (roundFinished)
        //    {
        //        foreach (var buttonElement in Managers.Gui.buttonElements.Values)
        //        {
        //            buttonElement.ChangeColor((Managers.Game.correctButton == buttonElement.button) ? Managers.Gui.successColor : Managers.Gui.failureColor);
        //        }
        //    }
        //    else
        //    {
        //        clickedButton.ChangeColor(color);
        //    }

        //}
        //else if (name.Equals("Animation Event"))
        //{
        //    MyAnimationEvent e = (MyAnimationEvent)obj;

        //    if (e.gameObject.name.Equals("Answers Panel") && e.name.Equals("End"))
        //    {
        //        ChangeState(new QuestionScreenState(stateMachine));
        //    }
        //}
    }
}
