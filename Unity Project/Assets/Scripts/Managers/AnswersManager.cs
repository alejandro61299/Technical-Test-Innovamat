using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Linq;

public class AnswersManager : MonoBehaviour
{
    public int maxAnswers = 3;
    public float answersSeparation = 96;
    public GameObject buttonPrefab;
    public GameObject buttonBackPrefab;

    private ButtonGuiElement correctButton;
    private List<int> answersList;
    private int correctAnswerIndex = 0;


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
    public void GenerateRoundInfo()
    {
        answersList = RandomEx.GetRandomNumbersList(maxAnswers);

        // Choose Correct Answer & Set Question Number Text

        correctAnswerIndex = Random.Range(0, answersList.Count);
        int correctNumber = answersList[correctAnswerIndex];
        string numberName = ((CatalanNumbers)correctNumber).ToString();
        Managers.Gui.ChangeText("Question Number Text", numberName);
    }

    public void InstanceButtons()
    {
        List<ButtonGuiElement> answersButtons =  Managers.Gui.GetButtonsByCollection(0);

        foreach (Transform child in transform)
        {
            if (child.CompareTag("Answer Button"))
            {
                Destroy(child.gameObject);
            }
        }

        // Instance Buttons in its correct position

        float offsetX = -((answersSeparation * ((float)maxAnswers - 1f)) * 0.5f);
        Vector2 position = new Vector2(offsetX, 0);

        for (int i = 0; i < maxAnswers; ++i)
        {
            // Instantiate Button Back
            GameObject buttonBack = Instantiate(buttonBackPrefab, transform);
            buttonBack.GetComponent<RectTransform>().anchoredPosition = position;
            buttonBack.name = i.ToString() + " Back";
            // Instantiate Button
            ButtonGuiElement button = Instantiate(buttonPrefab, transform).GetComponent<ButtonGuiElement>();
            button.GetComponent<RectTransform>().anchoredPosition = position;
            button.name = i.ToString();
            button.ChangeText(answersList[i].ToString());
        }

        correctButton = Managers.Gui.buttonElements[answersList[correctAnswerIndex].ToString()];
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