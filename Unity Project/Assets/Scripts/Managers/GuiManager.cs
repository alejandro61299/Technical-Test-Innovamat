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
    public List<string> collectionNames;

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

    }

    public void PlayAnimation(string elementName, string animationName)
    {
        if ( animatedElements.ContainsKey(elementName))
        {
            animatedElements[elementName].PlayAnimation(animationName);
        }
    }

    public void ChangeText(string elementName, string newText)
    {
        if (textElements.ContainsKey(elementName))
        {
            textElements[elementName].ChangeText(newText);
        }
    }

    public List<ButtonGuiElement> GetButtonsByCollection( int collection )
    {
        List<ButtonGuiElement> elements = new List<ButtonGuiElement>();

        foreach (ButtonGuiElement button in buttonElements.Values)
        {
            if (button.collection == collection)
            {
                elements.Add(button);
            }
        }

        return elements;
    }



}
