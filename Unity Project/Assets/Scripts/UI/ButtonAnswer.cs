using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using MyEvents;

public class ButtonAnswer : MonoBehaviour
{
    public Button button;
    public Text text;
    [HideInInspector] public AnswersPanel answersPanel;


    private void Start()
    {
        button.onClick.AddListener(OnClickButton);
    }

    public void ButtonInteraction( bool value)
    {
        button.interactable = value;
    }

    public void ChangeColor(Color color)
    {
        var colors = button.colors;

        colors.normalColor = colors.disabledColor = colors.selectedColor = colors.pressedColor  = color;
        button.colors = colors;
        button.image.color = color;
    }

    public void ChangeText(string newText)
    {
        text.text = newText;
    }

    void OnClickButton()
    {
        if (answersPanel.correctButton == this)
        {
            ChangeColor(answersPanel.successColor);
            EventManager.instance.TriggerEvent(MyEventType.CorrectButtonClicked, null);

        }
        else
        {
            ChangeColor(answersPanel.failureColor);
            EventManager.instance.TriggerEvent(MyEventType.InorrectButtonClicked, null);
        }

        ButtonInteraction(false);
    }
}
