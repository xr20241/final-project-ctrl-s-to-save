using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_E_Note : MonoBehaviour
{
    // Start is called before the first frame update
  public AudioSource E_Note;

  private void OnMouseDown()
  {
    {
        E_Note.Play();
    }
  }
}
