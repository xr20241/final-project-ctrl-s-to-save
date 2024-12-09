using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public GameObject lights;

    public GameObject piano;
    public GameObject lever;
    public GameObject equation;

    public Color red;
    public Color green;
    public Color blue;
    public Color white;
    // Start is called before the first frame update
    void Start()
    {
        lights.GetComponent<Light>().color = white;
         piano.SetActive(false);
        lever.SetActive(false);
        equation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        OVRInput.Update();
        if (OVRInput.Get(OVRInput.Button.One))
        {
            lights.GetComponent<Light>().color = red;
            piano.SetActive(true);
            lever.SetActive(false);
            equation.SetActive(false);
            Debug.Log("red");
        }
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            lights.GetComponent<Light>().color = green;
            piano.SetActive(false);
            lever.SetActive(true);
            equation.SetActive(false);
            Debug.Log("green");
        }
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            lights.GetComponent<Light>().color = blue;
            piano.SetActive(false);
            lever.SetActive(false);
            equation.SetActive(true);
            Debug.Log("blue");
        }
        if (OVRInput.Get(OVRInput.Button.Four))
        {
            lights.GetComponent<Light>().color = white;
            piano.SetActive(false);
            lever.SetActive(false);
            equation.SetActive(false);
            Debug.Log("white");
        }
    }
}