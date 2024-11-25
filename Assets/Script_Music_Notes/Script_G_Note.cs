using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_G_Note : MonoBehaviour
{
  public AudioSource G_Note;

  private void OnMouseDown()
  {
    {
        G_Note.Play();
    }
  }
}
