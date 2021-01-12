using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGuiElement : MonoBehaviour
{
    private void Awake()
    {
        if (Managers.Gui != null)
            Managers.Gui.buttonElements.Add(gameObject.name, this);
    }

    private void OnDestroy()
    {
        if (Managers.Gui != null)
            Managers.Gui.buttonElements.Remove(gameObject.name);
    }

    public void ChangeColor(Color color)
    {
        Button button = GetComponent<Button>();

        if (button == null)
        {
            var colors = button.colors;
            colors.disabledColor = colors.selectedColor = colors.selectedColor = color;
            button.colors = colors;
        }
    }
}
