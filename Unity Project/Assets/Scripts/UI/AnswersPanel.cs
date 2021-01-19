using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyEvents;

public class AnswersPanel : MonoBehaviour
{
    public Color successColor;
    public Color failureColor;
    public float answersSeparation = 96;
    public GameObject buttonPrefab;
    public GameObject buttonBackPrefab;
    private List<ButtonAnswer> buttons;
    [HideInInspector] public ButtonAnswer correctButton;


    private void Start()
    {
        buttons = new  List<ButtonAnswer>();
        EventManager.instance.StartListening(MyEventType.AnimAnswersPanelEnterEnd, ActiveButtons);
        EventManager.instance.StartListening(MyEventType.StateAnswersScreenEnter, ShowPanel);
        EventManager.instance.StartListening(MyEventType.EndRound, HidePanel);
        EventManager.instance.StartListening(MyEventType.EndRound, DeactiveButtons);

    }
    private void OnDestroy()
    {
        EventManager.instance.StopListening(MyEventType.AnimAnswersPanelEnterEnd, ActiveButtons);
        EventManager.instance.StopListening(MyEventType.StateAnswersScreenEnter, ShowPanel);
        EventManager.instance.StopListening(MyEventType.EndRound, HidePanel);
        EventManager.instance.StopListening(MyEventType.EndRound, DeactiveButtons);
    }


    void InstanceButtons()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Answer Button"))
            {
                ButtonAnswer buttonAnswer = child.GetComponent<ButtonAnswer>();
                if (buttonAnswer)
                {
                    buttons.Remove(buttonAnswer);
                }
                Destroy(child.gameObject);
            }
        }

        // Instance Buttons in its correct position

        float offsetX = -((answersSeparation * ((float)GameManager.instance.maxAnswers - 1f)) * 0.5f);
        Vector2 position = new Vector2(offsetX, 0);

        for (int i = 0; i < GameManager.instance.maxAnswers; ++i)
        {
            // Instantiate Button Back
            GameObject buttonBack = Instantiate(buttonBackPrefab, transform);
            buttonBack.GetComponent<RectTransform>().anchoredPosition = position;

            // Instantiate Button
            ButtonAnswer button = Instantiate(buttonPrefab, transform).GetComponent<ButtonAnswer>();
            button.answersPanel = this;
            button.GetComponent<RectTransform>().anchoredPosition = position;
            button.ChangeText(GameManager.instance.answersList[i].ToString());
            buttons.Add(button);

            position.x += answersSeparation;

            if (i == GameManager.instance.correctAnswerIndex)
            {
                correctButton = button;
            }
        }
    }

    void ChangeButtonsInteraction(bool value)
    {
        foreach (ButtonAnswer button in buttons)
        {
            button.ButtonInteraction(value);
        }
    }

    void ShowPanel ( EventInfo eventInfo )
    {
        InstanceButtons();
        GetComponent<Animator>().Play("Enter");
    }

    void HidePanel(EventInfo eventInfo)
    {
        GetComponent<Animator>().Play("Exit");
    }

    void ActiveButtons(EventInfo eventInfo)
    {
        ChangeButtonsInteraction(true);
    }

    void DeactiveButtons(EventInfo eventInfo)
    {
        ChangeButtonsInteraction(false);
    }
}