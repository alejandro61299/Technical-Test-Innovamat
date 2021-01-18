using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGuiElement : MonoBehaviour
{

    public void ChangeText(string newText)
    {
        Text text = GetComponent<Text>();

        if (text != null) 
            text.text = newText;
    }
}
