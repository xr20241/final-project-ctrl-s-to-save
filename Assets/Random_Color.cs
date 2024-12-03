using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Color : MonoBehaviour
{
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        item.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
