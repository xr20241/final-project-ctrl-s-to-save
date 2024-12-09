using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;

    private int numberShown;

    public Material highlightMaterial;
    public Material defaultMaterial;
    public GameObject Wheel;

    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 0;
    }

    public void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine("RotateWheel");
        }
    }

    private IEnumerator RotateWheel()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(0f, 3f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;

        numberShown += 1;

        if (numberShown > 9)
        {
            numberShown = 0;
        }

        Rotated(name, numberShown);
    }

    public void OnHoverEnter()
    {
        Wheel.GetComponent<Renderer>().material = highlightMaterial;
    }

    public void OnHoverExit()
    {
        Wheel.GetComponent<Renderer>().material = defaultMaterial;
    }
}
