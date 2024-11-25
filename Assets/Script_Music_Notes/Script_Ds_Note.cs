using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Ds_Note : MonoBehaviour
{
  public AudioSource Ds_Note;

  private void OnMouseDown()
  {
    {
        Ds_Note.Play();
    }
  }
}
