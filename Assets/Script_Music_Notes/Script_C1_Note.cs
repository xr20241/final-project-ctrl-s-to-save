using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_C1_Note : MonoBehaviour
{
  public AudioSource C1_Note;

  private void OnMouseDown()
  {
    {
        C1_Note.Play();
    }
  }
}
