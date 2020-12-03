﻿using System.Collections;
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
        aPanel.Play("None");
        aPanel.gameObject.SetActive(false);
    }
    public override void Event(string name, object obj)
    {
        if (name.Equals("OnClickButton"))
        {
            Button button = (Button)obj;
            int number = int.Parse(button.name);
            if (number == Managers.Game.currentNumber)
            {

            }
            else
            {

            }
        }


        if (name.Equals("Anim Out End"))
        {
            ChangeState(new ResultScreenState(stateMachine));
        }
    }
}