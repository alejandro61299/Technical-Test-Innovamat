using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreNumbersScript : MonoBehaviour
{
    public void SyncNumber()
    {
        Text text = GetComponent<Text>();
        if (text != null)
        {
            if (gameObject.name.Equals("Success Num"))
            {
                text.text = Managers.Game.success.ToString();
            }
            if (gameObject.name.Equals("Failures Num"))
            {
                text.text = Managers.Game.failures.ToString();
            }
        }
    }
}
