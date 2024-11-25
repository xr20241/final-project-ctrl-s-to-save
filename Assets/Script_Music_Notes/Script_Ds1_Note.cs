using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Ds1_Note : MonoBehaviour
{
  public AudioSource Ds1_Note;

  private void OnMouseDown()
  {
    {
        Ds1_Note.Play();
    }
  }
}
