using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_D1_Note : MonoBehaviour
{
  public AudioSource D1_Note;

  private void OnMouseDown()
  {
    {
        D1_Note.Play();
    }
  }
}
