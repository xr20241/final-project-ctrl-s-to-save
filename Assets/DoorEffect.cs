using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEffect : MonoBehaviour
{
    public Animator doorAnimator;
    public Animator blueAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            doorAnimator.SetBool("Open", true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            doorAnimator.SetBool("Open", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //blueAnimator.SetBool("Blue", true);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //blueAnimator.SetBool("Blue", false);
        }
        
        
    }
}
