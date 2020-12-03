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

    [HideInInspector] public StateMachine gameStateMachine { get; private set; }
    private void Awake()
    {
        Managers.Game = this;
    }
    void Start()
    {
        gameStateMachine = GetComponent<StateMachine>();
        gameStateMachine.ChangeState(new QuestionScreenState(gameStateMachine), 1.5f);
    }
    void Update()
    {
        
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
        }

        // Choose Correct Answer & Set Question Number Text

        int correctAnswer = Random.Range(0, numbers.Count);
        int currentNumber = numbers[correctAnswer];
        string numberName = ((CatalanNumbers)currentNumber).ToString();
        Managers.Gui.numberText.text = numberName;


        // Set Buttons Text 
        int j = 0;
        foreach (var par in Managers.Gui.buttons)
        {
            Button button = par.Value;
            button.GetComponentInChildren<Text>().text = numbers[j++].ToString(); 
        }


    }
}
