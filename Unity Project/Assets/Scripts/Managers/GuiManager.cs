using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonBackPrefab;
    public Text numberText;
    public GameObject answersPanel;
    public int maxAnswers;
    public float answersSeparation;

    [HideInInspector] public Dictionary<string, Animator> animators { get; private set; }
    [HideInInspector] public Dictionary<string, Button> buttons { get; private set; }

    private void Awake()
    {
        Managers.Gui = this;
        buttons = new Dictionary<string, Button>();
        animators = new Dictionary<string, Animator>();
    }
    void Start()
    {
        float initX = - ((answersSeparation * ((float)maxAnswers - 1f)) / 2f);

        for (int i = 0; i < maxAnswers; ++i )
        {
            // Instantiate Button Back
            GameObject buttonBack = Instantiate(buttonBackPrefab, answersPanel.transform);
            buttonBack.GetComponent<RectTransform>().anchoredPosition = new Vector2(initX, 0);
            buttonBack.name = i.ToString() + " Back";
            // Instantiate Button
            Button button = Instantiate(buttonPrefab, answersPanel.transform).GetComponent<Button>();
            button.GetComponent<RectTransform>().anchoredPosition = new Vector2(initX, 0);
            button.name = i.ToString();

            initX += answersSeparation;

            buttons.Add(button.name, button);
            button.onClick.AddListener(() => { OnClickButton(button.name, button); });
        }

        Animator[] arAnimators = FindObjectsOfType<Animator>();

        foreach( var animator in arAnimators)
        {
            animators.Add( animator.name , animator);
            animator.gameObject.SetActive(false);
        }
    }
    public void OnClickButton( string name, Button button)
    {
        Managers.Game.gameStateMachine.StateEvent(name, button);
    }

    public void ResetButtons()
    {
        foreach( var par in buttons)
        {
            Button button = par.Value;
            button = Instantiate(buttonPrefab.GetComponent<Button>());
            button.onClick.AddListener(() => { OnClickButton(button.name, button); });
        }
    }

}
