using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEvents;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour
{
    public Text questionNumber;

    void Start()
    {
        EventManager.instance.StartListening(MyEventType.StateQuestionScreenEnter, ShowPanel);
        EventManager.instance.StartListening( MyEventType.QuestionShowTimeEnd , HidePanel);
        EventManager.instance.StartListening( MyEventType.RoundDataGenerated , SetQuestionText);

    }

    public void ShowPanel(EventInfo eventInfo)
    {
        GetComponent<Animator>().Play("Enter");
    }

    public void HidePanel(EventInfo eventInfo)
    {
        GetComponent<Animator>().Play("Exit");
    }

    public void SetQuestionText(EventInfo eventInfo)
    {
        int num;
        string name;
        GameManager.instance.GetCorrectAnswer(out num, out name);
        questionNumber.text = name;
    }


}
