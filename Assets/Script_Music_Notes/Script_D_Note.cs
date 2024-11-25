using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_D_Note : MonoBehaviour
{
  public AudioSource D_Note;

  private void OnMouseDown()
  {
    {
        D_Note.Play();
    }
  }
}
