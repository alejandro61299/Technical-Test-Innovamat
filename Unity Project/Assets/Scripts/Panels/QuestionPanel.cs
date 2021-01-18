using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEvents;

public class QuestionPanel : MonoBehaviour
{
    

    void Start()
    {
        EventSystem.instance.RegisterListener("Question")
    }

    void ShowPanel(EventInfo eventInfo)
    {
        GetComponent<Animator>().Play("Enter");
    }
}
