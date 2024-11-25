using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Cs_Note : MonoBehaviour
{
  public AudioSource Cs_Note;

  private void OnMouseDown()
  {
    {
        Cs_Note.Play();
    }
  }
}
