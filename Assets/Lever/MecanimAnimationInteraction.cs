using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public abstract class MecanimAnimationInteraction : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private bool canRevertState;

    protected bool inInitialState = true;
    private bool inProgress;

    void Start()
    {
        this.anim = this.GetComponent<Animator>();
    }

    public virtual IEnumerator Interact()
    {
        this.inProgress = true;

        if (this.inInitialState)
            this.anim.SetTrigger("Down");
        else this.anim.SetTrigger("Up");
        this.inInitialState = !this.inInitialState;

        AnimatorStateInfo animInfo = this.anim.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(animInfo.length);
        this.inProgress = false;
    }

    public virtual void SetActiveInteraction(bool val)
    {   
    }

    public abstract string InteractionText { get; }
    public bool inProgress_pub {get {return this.inProgress; }}
}