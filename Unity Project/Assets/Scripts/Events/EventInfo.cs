using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyEvents
{

    public abstract class EventInfo
    {
        public string description;
    }

    public class RoundStartEventInfo : EventInfo
    {
        public int correctButtonId;
    }

    public class RoundEmdEventInfo : EventInfo
    {
        public bool playerWin = false;
    }

    public class AnimationEventInfo : EventInfo
    {
        public AnimationClip clip;
        public GameObject gameObject;
    }

}


