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

    [HideInInspector] public Dictionary<string, TextGuiElement> textElements { get; private set; }
    [HideInInspector] public Dictionary<string, ButtonGuiElement> buttonElements { get; private set; }
    [HideInInspector] public Dictionary<string, AnimatedGuiElement> animatedElements { get; private set; }

    private void Awake()
    {
        Managers.Gui = this;
        buttonElements = new Dictionary<string, ButtonGuiElement>();
        textElements = new Dictionary<string, TextGuiElement>();
        animatedElements = new Dictionary<string, AnimatedGuiElement>();
    }
    void Start()
    {
        AnswersManager aButtons = GameObject.FindObjectOfType<AnswersManager>();
        aButtons.InstanceButtons();
    }

    public void PlayAnimation(string elementName, string animationName)
    {
        if (animatedElements[elementName] != null)
        {
            animatedElements[elementName].PlayAnimation(animationName);
        }
    }

    public void ChangeText(string elementName, string newText)
    {
        if (textElements[elementName] != null)
        {
            textElements[elementName].ChangeText(newText);
        }
    }

}
