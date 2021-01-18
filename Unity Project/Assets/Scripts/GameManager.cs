using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyEvents;

public enum CatalanNumbers { Zero = 0, Un = 1, Dos = 2, Tres = 3, Quatre = 4, Cinc = 5, Sis = 6, Set = 7, Vuit = 8, Nou = 9, Deu = 10 }

public class GameManager : MonoBehaviour
{
    private static GameManager current;
    public static GameManager instance
    {
        get
        {
            if (current == null)
            {
                current = GameObject.FindObjectOfType<GameManager>();
            }
            return current;
        }
    }


    // Game Data ---------------------
    public int currentNumber { get; private set; }
    public int success { get; private set; }
    public int failures { get; private set; }

    [HideInInspector] public ButtonGuiElement correctButton { get; private set; }
    [HideInInspector] public StateMachine gameStateMachine { get; private set; }
    [HideInInspector] public AnswersPanel answersManager { get; private set; }

    [HideInInspector] public  List<int> answersList;
    public int maxAnswers = 3;
    public int correctAnswerIndex = 0;


    void Start()
    {
        // Events Register 
        EventSystem.instance.RegisterListener("StartRound", StratRound);
        EventSystem.instance.RegisterListener("EndRound", EndRound);

        gameStateMachine = GetComponent<StateMachine>();
        gameStateMachine.ChangeState(new QuestionScreenState(gameStateMachine), 1.5f);
    }

    private void OnDestroy()
    {
        EventSystem.instance.UnregisterListener("StartRound", StratRound);
        EventSystem.instance.UnregisterListener("EndRound", EndRound);
    }

    void StratRound( EventInfo ei)
    {
        GenerateRoundInfo();
        EventSystem.instance.CallEvent("RoundInfoGenerated", null );
;    }


    void EndRound( EventInfo ei)
    {
        RoundEmdEventInfo info = (RoundEmdEventInfo)ei;
        if ( info.playerWin )
        {
            ++success;
        }
        else
        {
            ++failures;
        }
    }

    public void GenerateRoundInfo()
    {
        // Choose Correct Answer & Set Question Number Text

        answersList = RandomEx.GetRandomNumbersList(maxAnswers);
        correctAnswerIndex = Random.Range(0, answersList.Count);
        int correctNumber = answersList[correctAnswerIndex];
        
        // TODO: Add scriptable object with traductions
        string numberName = ((CatalanNumbers)correctNumber).ToString();



        //Managers.Gui.ChangeText("Question Number Text", numberName);

    }
}
