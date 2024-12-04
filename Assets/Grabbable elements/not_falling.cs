using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class not_falling : MonoBehaviour
{
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (item.transform.position.y < 0)
        {
            item.transform.position = new Vector3(item.transform.position.x, 0, item.transform.position.z);
        }
    }
}
