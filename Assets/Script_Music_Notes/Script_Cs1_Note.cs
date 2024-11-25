using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Cs1_Note : MonoBehaviour
{
  public AudioSource Cs1_Note;

  private void OnMouseDown()
  {
    {
        Cs1_Note.Play();
    }
  }
}
