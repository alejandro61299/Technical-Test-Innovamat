using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGuiElement : MonoBehaviour
{
    public Button button { get; private set; }
    public Text text { get; private set; }

    public void ChangeColor(Color color)
    {
        if (button != null)
        {
            var colors = button.colors;
            colors.disabledColor = colors.selectedColor = colors.selectedColor = color;
            button.colors = colors;
        }
    }

    public void ChangeText(string newText)
    {
        if(text != null)
        {
            text.text = newText;
        }
    }
}
