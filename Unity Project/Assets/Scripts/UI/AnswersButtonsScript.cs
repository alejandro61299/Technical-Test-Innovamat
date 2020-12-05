using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Linq;

public class AnswersButtonsScript : MonoBehaviour
{
    public int maxAnswers = 3;
    public float answersSeparation = 96;
    public GameObject buttonPrefab;
    public GameObject buttonBackPrefab;

    public void ButtonsInteraction(bool value)
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
        // Remove from Buttons Dictionary

        foreach (Transform child in transform)
        {
            if (child.CompareTag("Answer Button"))
            {
                Managers.Gui.buttons.Remove(child.gameObject.name);
                Destroy(child.gameObject);
            }
        }

        // Instance Buttons in its correct pos

        float initX = -((answersSeparation * ((float)maxAnswers - 1f)) / 2f);

        for (int i = 0; i < maxAnswers; ++i)
        {
            // Instantiate Button Back
            GameObject buttonBack = Instantiate(buttonBackPrefab, transform);
            buttonBack.GetComponent<RectTransform>().anchoredPosition = new Vector2(initX, 0);
            buttonBack.name = i.ToString() + " Back";
            // Instantiate Button
            Button button = Instantiate(buttonPrefab, transform).GetComponent<Button>();
            button.GetComponent<RectTransform>().anchoredPosition = new Vector2(initX, 0);
            button.name = i.ToString();
            // Add to Buttons List 
            Managers.Gui.buttons.Add(button.name, button);
            button.onClick.AddListener(() => { Managers.Game.gameStateMachine.StateEvent("OnClickButton", button); });
            initX += answersSeparation;
        }
    }
}


// Alternative Remove from Buttons Dictionary

/* var toRemove = Managers.Gui.buttons.
    Where(pair => pair.Value.CompareTag("Answer Button")).
    Select(pair => pair.Key).ToList();

foreach (var key in toRemove)
{
    Managers.Gui.buttons.Remove(key);
}
*/