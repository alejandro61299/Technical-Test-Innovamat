using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimationEvent
{
    public MyAnimationEvent(string name, AnimationClip clip, GameObject gameObject)
=> (this.name, this.clip, this.gameObject) = (name, clip, gameObject);

    public string name;
    public AnimationClip clip;
    public GameObject gameObject;
}

public class AnimationEvents : MonoBehaviour
{
    public void AnimationEvent(AnimationEvent evt)
    {
        MyAnimationEvent e = new MyAnimationEvent(evt.stringParameter,evt.animatorClipInfo.clip , gameObject );
        Managers.Game.gameStateMachine.StateEvent("Animation Event", e);
    }
}
