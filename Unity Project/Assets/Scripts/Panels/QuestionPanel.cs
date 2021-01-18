using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEvents;

public class QuestionPanel : MonoBehaviour
{
    void Start()
    {
        EventManager.instance.RegisterListener("QuestionScreenStateEnter", ShowPanel);
        EventManager.instance.RegisterListener("QuestionShowTimeEnd", HidePanel);
    }

    public void ShowPanel(EventInfo eventInfo)
    {
        GetComponent<Animator>().Play("Enter");
    }

    public void HidePanel(EventInfo eventInfo)
    {
        GetComponent<Animator>().Play("Exit");
    }
}
