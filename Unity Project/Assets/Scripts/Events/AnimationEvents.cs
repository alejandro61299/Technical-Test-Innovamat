using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void AnimationEvent( string name )
    {
        Managers.Game.gameStateMachine.StateEvent(name, null);
    }

}
