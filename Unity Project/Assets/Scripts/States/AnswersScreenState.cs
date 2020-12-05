using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswersScreenState : State
{
    private int maxErrors;
    private int currentErrors;
    private Animator aPanel;
    private AnswersButtonsScript aButtons;
    private bool activeInput = false;

    public AnswersScreenState(StateMachine stateMachine) : base(stateMachine)
    { }
    public override void Enter()
    {
        currentErrors = 0;
        maxErrors = 2;
        aPanel = Managers.Gui.animators["Answers Panel"];
        aPanel.gameObject.SetActive(true);
        aButtons = aPanel.GetComponent<AnswersButtonsScript>();
        aPanel.Play("Bounce");

    }
    public override void Update()
    {
        bool isIdle = aPanel.GetCurrentAnimatorStateInfo(0).IsName("Idle");

        if (activeInput != isIdle)
        {
            activeInput = isIdle;
            aButtons.ButtonsInteraction(activeInput);
        }

    }

    public override void Exit()
    {
        aButtons.InstanceButtons();
        aPanel.Play("None");
        aPanel.gameObject.SetActive(false);
    }

    private void TintButton(Button button, Color color)
    {
        var colors = button.colors;
        colors.disabledColor = colors.selectedColor = colors.selectedColor = color;
        button.colors = colors;
    }

    public override void Event(string name, object obj)
    {
        if (name.Equals("OnClickButton"))
        {
            Color color;
            bool tintAll = false;
            Button clickedButton = (Button)obj;

            if (Managers.Game.correctButton == clickedButton)
            {
                color = Managers.Gui.successColor;
                aPanel.Play("Idle To Out");
                Managers.Game.AddScorePoint(false);
                tintAll = true;
            }
            else
            {
                color = Managers.Gui.failureColor;
                clickedButton.GetComponent<Animator>().Play("Out");
                ++currentErrors;

                if ( currentErrors == maxErrors)
                {
                    aPanel.Play("Idle To Out");
                    Managers.Game.AddScorePoint(true);
                    tintAll = true;
                }
            }

            if (tintAll)
            {
                foreach ( var pair in Managers.Gui.buttons)
                {
                    TintButton(pair.Value, (Managers.Game.correctButton == pair.Value) ? Managers.Gui.successColor : Managers.Gui.failureColor);
                }
            }
            else
            {
                TintButton(clickedButton, color);
            }

        }
        else if (name.Equals("Animation Event"))
        {
            MyAnimationEvent e = (MyAnimationEvent)obj;

            if (e.gameObject.name.Equals("Answers Panel") && e.name.Equals("End"))
            {
                ChangeState(new QuestionScreenState(stateMachine));
            }
        }
    }
}
