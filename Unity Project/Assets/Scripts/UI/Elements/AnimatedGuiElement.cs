using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedGuiElement : MonoBehaviour
{
    private void Awake()
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

        if (animator == null) 
            animator.Play(animationName);
    }
}
