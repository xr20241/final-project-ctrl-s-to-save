using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Fs_Note : MonoBehaviour
{
  public AudioSource Fs_Note;

  private void OnMouseDown()
  {
    {
        Fs_Note.Play();
    }
  }
}
