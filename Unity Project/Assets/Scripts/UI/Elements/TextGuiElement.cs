using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGuiElement : MonoBehaviour
{
    private void Start()
    {
        if (Managers.Gui != null)
            Managers.Gui.textElements.Add(gameObject.name, this);
    }

    private void OnDestroy()
    {
        if (Managers.Gui != null)
            Managers.Gui.textElements.Remove(gameObject.name);
    }

    public void ChangeText(string newText)
    {
        Text text = GetComponent<Text>();

        if (text != null) 
            text.text = newText;
    }
}
