using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedGuiElement : MonoBehaviour
{
    private void Start()
    {
        if (Managers.Gui != null) 
            Managers.Gui.animatedElements.Add( gameObject.name, this);
    }

    private void OnDestroy()
    {
        if (Managers.Gui != null)
            Managers.Gui.animatedElements.Remove(gameObject.name);
    }

    public void PlayAnimation(string animationName)
    {
        Animator animator = GetComponent<Animator>();

        if (animator != null) 
            animator.Play(animationName);
    }

    public bool IsStateName( string stateName)
    {
        Animator animator = GetComponent<Animator>();

        if (animator != null)
            return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
        else
            return false;
    }
}
