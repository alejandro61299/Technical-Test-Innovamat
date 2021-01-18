using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEvents;



public class AnimationEvents : MonoBehaviour
{
    public void AnimationEvent(AnimationEvent evt)
    {
        AnimationEventInfo info = new AnimationEventInfo();
        info.clip = evt.animatorClipInfo.clip;
        info.gameObject = gameObject;
        EventManager.instance.CallEvent(evt.stringParameter, info);
    }
}
