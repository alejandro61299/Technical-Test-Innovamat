using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyEvents;

public class AnswersPanel : MonoBehaviour
{

    public float answersSeparation = 96;
    public GameObject buttonPrefab;
    public GameObject buttonBackPrefab;

    private ButtonGuiElement correctButton;
    private List<ButtonGuiElement> buttons;

    private void Start()
    {
        buttons = new  List<ButtonGuiElement>();
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
            ButtonGuiElement button = Instantiate(buttonPrefab, transform).GetComponent<ButtonGuiElement>();
            button.GetComponent<RectTransform>().anchoredPosition = position;
            button.ChangeText(GameManager.instance.answersList[i].ToString());

            position.x += answersSeparation;

            if (i == GameManager.instance.correctAnswerIndex)
            {
                correctButton = button;
            }
        }
    }

    void ChangeButtonsInteraction(bool value)
    {
        foreach (Transform child in transform)
        {
            Button button = child.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = value;
            }
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