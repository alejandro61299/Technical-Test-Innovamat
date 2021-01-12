using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGuiElement : MonoBehaviour
{
    public Button button { get; private set; }
    public string collection = "Default";
    private void Awake()
    {
        button = GetComponent<Button>();

        if (Managers.Gui != null && button != null)
        {
            Managers.Gui.buttonElements.Add(gameObject.name, this);
            button.onClick.AddListener(() => { Managers.Game.gameStateMachine.StateEvent("OnClickButton", this); });
        }
           
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
