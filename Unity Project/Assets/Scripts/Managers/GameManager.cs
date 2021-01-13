using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CatalanNumbers { Zero = 0, Un = 1, Dos = 2, Tres = 3, Quatre = 4, Cinc = 5, Sis = 6, Set = 7, Vuit = 8, Nou = 9, Deu = 10 }

public class GameManager : MonoBehaviour
{
    // Game Data ---------------------
    public int currentNumber { get; private set; }
    public int success { get; private set; }
    public int failures { get; private set; }

    [HideInInspector] public ButtonGuiElement correctButton { get; private set; }
    [HideInInspector] public StateMachine gameStateMachine { get; private set; }
    [HideInInspector] public AnswersManager answersManager { get; private set; }

    private void Awake()
    {
        Managers.Game = this;
    }
    void Start()
    {
        answersManager = FindObjectOfType<AnswersManager>();
        gameStateMachine = GetComponent<StateMachine>();
        gameStateMachine.ChangeState(new QuestionScreenState(gameStateMachine), 1.5f);
    }

    public void AddScorePoint(bool hasFailed)
    {
        if (hasFailed)
        {
            ++failures;
            Managers.Gui.PlayAnimation("Failures Num" , "Score");

        }
        else
        {
            ++success;
            Managers.Gui.PlayAnimation("Success Num", "Score");
        }
    }

}
