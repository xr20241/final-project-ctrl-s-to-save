using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobEffect : MonoBehaviour
{
    public Animator mainAnimator;
    public Animator other1Animator;
    public Animator other2Animator;
    public Material highlightMaterial;
    public Material defaultMaterial;
    public GameObject knob;
    public GameObject lightComponent;
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnTriggerEnter()
    {
        if (mainAnimator.GetBool("ON") == false)
        {
            mainAnimator.SetBool("ON", true);
            lightComponent.GetComponent<Renderer>().material.color = color;
            other1Animator.SetBool("ON", false);
            other2Animator.SetBool("ON", false);
        }
        else if (mainAnimator.GetBool("ON") == true)
        {
            mainAnimator.SetBool("ON", false);
            lightComponent.GetComponent<Renderer>().material.color = Color.white;
        }
    }



    public void OnHoverEnter()
    {
        knob.GetComponent<Renderer>().material = highlightMaterial;
    }

    public void OnHoverExit()
    {
        knob.GetComponent<Renderer>().material = defaultMaterial;
    }
}
