using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    public Animator leverAnimator;
    public Material highlightMaterial;
    public Material defaultMaterial;
    public GameObject Stick;
    public int index;
    // Start is called before the first frame update
    void Start() {}
    void Update() {}

    public void OnTriggerEnter()
    {
        if (leverAnimator.GetBool("Down") == false)
        {
            leverAnimator.SetBool("Down", true);
            LeverAnswer.LeverSequence[index] = "Down";
        }
        else if (leverAnimator.GetBool("Down") == true)
        {
            leverAnimator.SetBool("Down", false);
            LeverAnswer.LeverSequence[index] = "Up";
        }
    }

    public void OnHoverEnter()
    {
        Stick.GetComponent<Renderer>().material = highlightMaterial;
    }

    public void OnHoverExit()
    {
        Stick.GetComponent<Renderer>().material = defaultMaterial;
    }
}
