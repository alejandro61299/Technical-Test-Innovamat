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
        EventManager.instance.RegisterListener("AnswersScreenStateEnter", ShowPanel);
        EventManager.instance.RegisterListener("EndRound", HidePanel);
    }
    private void OnDestroy()
    {
        EventManager.instance.UnregisterListener("AnswerScreenStateEnter", ShowPanel);
        EventManager.instance.UnregisterListener("EndRound", HidePanel);
    }   

    public void ActiveButtonsInteractions(bool value)
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
    public void InstanceButtons()
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
            buttonBack.name = i.ToString() + " Back";
            // Instantiate Button
            ButtonGuiElement button = Instantiate(buttonPrefab, transform).GetComponent<ButtonGuiElement>();
            button.GetComponent<RectTransform>().anchoredPosition = position;
            button.name = i.ToString();
            button.ChangeText(GameManager.instance.answersList[i].ToString());

            if (i == GameManager.instance.correctAnswerIndex)
            {
                correctButton = button;
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
}