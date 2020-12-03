using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswersScreenState : State
{
    private int maxErrors = 2;
    private int currentErrors = 0;
    private Animator aPanel;
    public AnswersScreenState(StateMachine stateMachine) : base(stateMachine)
    { }
    public override void Enter()
    {
        aPanel = Managers.Gui.animators["Answers Panel"];
        aPanel.gameObject.SetActive(true);
        aPanel.Play("Bounce");
    }
    public override void Update()
    {

    }
    public override void Exit()
    {
        Managers.Gui.CreateButtons();
        aPanel.Play("None");
        aPanel.gameObject.SetActive(false);
    }
    public override void Event(string name, object obj)
    {
        if (name.Equals("OnClickButton"))
        {
            Button button = (Button)obj;
            int number = int.Parse(button.GetComponentInChildren<Text>().text);
            Color color;
            if (number == Managers.Game.currentNumber)
            {
                color = Managers.Gui.successColor;
                //ChangeState(new ResultScreenState(stateMachine));
                aPanel.Play("Idle To Out");
            }
            else
            {
                ++currentErrors;
                color = Managers.Gui.failureColor;
                button.GetComponent<Animator>().Play("Out");

            }
            var colors = button.colors;
            colors.disabledColor = color;
            colors.selectedColor = color;
            button.colors = colors;
            button.interactable = false;


            if (currentErrors >= maxErrors)
            {
                aPanel.Play("Idle To Out");
            }

        }
        else if (name.Equals("Anim Out End"))
        {
            ChangeState(new QuestionScreenState(stateMachine));
        }
    }
}
