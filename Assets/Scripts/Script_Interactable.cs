using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Script_Interactable : MonoBehaviour
{
    Outline outline;
    public string message;

    public UnityEvent OnInteraction;
    
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

   public void Interact()
   {
        OnInteraction.Invoke();
   }
   
    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
