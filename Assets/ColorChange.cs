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
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            lights.GetComponent<Light>().color = red;
            piano.SetActive(true);
            lever.SetActive(false);
            equation.SetActive(false);
            Debug.Log("red");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            lights.GetComponent<Light>().color = green;
            piano.SetActive(false);
            lever.SetActive(true);
            equation.SetActive(false);
            Debug.Log("green");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            lights.GetComponent<Light>().color = blue;
            piano.SetActive(false);
            lever.SetActive(false);
            equation.SetActive(true);
            Debug.Log("blue");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            lights.GetComponent<Light>().color = white;
            piano.SetActive(false);
            lever.SetActive(false);
            equation.SetActive(false);
            Debug.Log("white");
        }
    }
}