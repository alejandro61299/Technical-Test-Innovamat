using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    [ColorUsageAttribute(true)]
    public Color failureColor;
    [ColorUsageAttribute(true)]
    public Color successColor;

    [HideInInspector] public Dictionary<string, Animator> animators { get; private set; }
    [HideInInspector] public Dictionary<string, Button> buttons { get; private set; }
    [HideInInspector] public Dictionary<string, Text> texts { get; private set; }


    [HideInInspector] public Dictionary<string, TextGuiElement> textElements { get; private set; }
    [HideInInspector] public Dictionary<string, ButtonGuiElement> buttonElements { get; private set; }
    [HideInInspector] public Dictionary<string, AnimatedGuiElement> animatedElements { get; private set; }

    private void Awake()
    {
        Managers.Gui = this;
        buttons = new Dictionary<string, Button>();
        animators = new Dictionary<string, Animator>();
        texts = new Dictionary<string, Text>();

        buttonElements = new Dictionary<string, ButtonGuiElement>();
        textElements = new Dictionary<string, TextGuiElement>();
        animatedElements = new Dictionary<string, AnimatedGuiElement>();
    }
    void Start()
    {

        AnswersButtonsScript aButtons = GameObject.FindObjectOfType<AnswersButtonsScript>();
        aButtons.InstanceButtons();

        GameObject[] auGameObj = GameObject.FindGameObjectsWithTag("Animated UI");

        foreach( var go in auGameObj)
        {
            Animator animatorPanel = go.GetComponent<Animator>();
            if (animatorPanel == null) continue;
            animators.Add(animatorPanel.name , animatorPanel);
        }

        GameObject[] dtGameObj = GameObject.FindGameObjectsWithTag("Dynamic Text");

        foreach (var go in dtGameObj)
        {
            Text dynText = go.GetComponent<Text>();
            if (dynText == null) continue;
            texts.Add(dynText.name, dynText);
        }
    }


}
