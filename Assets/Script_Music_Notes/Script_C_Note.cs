using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_C_Note : MonoBehaviour
{
  public AudioSource C_Note;

  private void OnMouseDown()
  {
    {
        C_Note.Play();
    }
  }
}
