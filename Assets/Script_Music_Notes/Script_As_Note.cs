using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_As_Note : MonoBehaviour
{
  public AudioSource As_Note;

  private void OnMouseDown()
  {
    {
        As_Note.Play();
    }
  }
}
