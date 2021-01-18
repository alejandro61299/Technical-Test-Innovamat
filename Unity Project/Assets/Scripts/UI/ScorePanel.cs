using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyEvents;

public class ScorePanel : MonoBehaviour
{
    public GameObject succesNum;
    public GameObject failuresNum;

    private void Start()
    {
        EventManager.instance.RegisterListener(  MyEventType.EndRound , EndRound);
    }

    void EndRound(EventInfo ei)
    {
        RoundEmdEventInfo info = (RoundEmdEventInfo)ei;
        if (info.playerWin)
        {

        }
        else
        {

        }


    }


    public void SyncNumber()
    {
        Text text = GetComponent<Text>();
        if (text != null)
        {
            //if (gameObject.name.Equals("Success Num"))
            //{
            //    text.text = Managers.Game.success.ToString();
            //}
            //if (gameObject.name.Equals("Failures Num"))
            //{
            //    text.text = Managers.Game.failures.ToString();
            //}
        }
    }
}
