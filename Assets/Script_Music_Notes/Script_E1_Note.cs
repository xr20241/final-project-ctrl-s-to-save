using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_E1_Note : MonoBehaviour
{
    // Start is called before the first frame update
  public AudioSource E1_Note;

  private void OnMouseDown()
  {
    {
        E1_Note.Play();
    }
  }
}
