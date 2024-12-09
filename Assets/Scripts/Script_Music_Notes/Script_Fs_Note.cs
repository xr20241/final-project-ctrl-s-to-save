using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Fs_Note : MonoBehaviour
{
  public AudioSource Fs_Note;
  public Material highlightMaterial;
  public Material defaultMaterial;
  public GameObject Key;

  public void OnMouseDown()
  {
    Fs_Note.Play();
    ResetButton.KeysPlayed.Add("F#");
    ResetButton.index = ResetButton.index + 1;
  }

  public void OnHoverEnter()
  {
    Key.GetComponent<Renderer>().material = highlightMaterial;
  }

  public void OnHoverExit()
  {
    Key.GetComponent<Renderer>().material = defaultMaterial;
  }
}
