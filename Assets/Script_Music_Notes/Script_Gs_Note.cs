using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Gs_Note : MonoBehaviour
{
  public AudioSource Gs_Note;

  private void OnMouseDown()
  {
    {
        Gs_Note.Play();
    }
  }
}
