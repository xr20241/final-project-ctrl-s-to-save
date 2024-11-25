using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_F1_Note : MonoBehaviour
{
    // Start is called before the first frame update
  public AudioSource F1_Note;

  private void OnMouseDown()
  {
    {
        F1_Note.Play();
    }
  }
}