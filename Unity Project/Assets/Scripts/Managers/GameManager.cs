using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Game Data ---------------------
    enum CatalanNumbers { Zero = 0, Un = 1, Dos = 2, Tres = 3, Quatre = 4, Cinc = 5, Sis = 6, Set = 7, Vuit = 8, Nou = 9, Deu = 10}
    public int currentNumber { get; private set; }
    public int success { get; private set; }
    public int failures { get; private set; }

    [HideInInspector] public Button correctButton { get; private set; }
    [HideInInspector] public StateMachine gameStateMachine { get; private set; }

    private ScoreNumbersScript scoreNumbers;

    private void Awake()
    {
        Managers.Game = this;
    }
    void Start()
    {
        gameStateMachine = GetComponent<StateMachine>();
        gameStateMachine.ChangeState(new QuestionScreenState(gameStateMachine), 1.5f);
    }

    public void PrepareNewRound()
    {
        // Generate different Randoms list

        List<int> numbers = new List<int>();

        while (Managers.Gui.buttons.Count != numbers.Count) 
            numbers.Add(-1);

        for (int i = 0; i < numbers.Count; ++i)
        {
            int newRandom;
            do {
                newRandom = Random.Range(0, 11);
            }
            while (numbers.Contains(newRandom));

            numbers[i] = newRandom;

            Managers.Gui.buttons[i.ToString()].GetComponentInChildren<Text>().text = numbers[i].ToString(); // Set Buttons Text 
        }

        // Choose Correct Answer & Set Question Number Text

        int randomIndex = Random.Range(0, numbers.Count);
        currentNumber = numbers[randomIndex];
        correctButton = Managers.Gui.buttons[randomIndex.ToString()];
        string numberName = ((CatalanNumbers)currentNumber).ToString();
        Managers.Gui.texts["Question Number Text"].text = numberName;
    }
    public void AddScorePoint(bool hasFailed)
    {
        if (hasFailed)
        {
            ++failures;
            Managers.Gui.texts["Failures Num"].GetComponent<Animator>().Play("Score");

        }
        else
        {
            ++success;
            Managers.Gui.texts["Success Num"].GetComponent<Animator>().Play("Score");
        }
    }

}
