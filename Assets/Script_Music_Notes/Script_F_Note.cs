using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_F_Note : MonoBehaviour
{
  public AudioSource F_Note;

  private void OnMouseDown()
  {
    {
        F_Note.Play();
    }
  }
}