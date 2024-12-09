using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public GameObject cameras;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft))
        {
            cameras.transform.Rotate(0, -1, 0);
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight))
        {
            cameras.transform.Rotate(0, 1, 0);
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            cameras.transform.Translate(0.01f, 0, 0);
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {
            cameras.transform.Translate(-0.01f, 0, 0);
        }
    }
}
