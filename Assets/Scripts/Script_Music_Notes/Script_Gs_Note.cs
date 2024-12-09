using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Gs_Note : MonoBehaviour
{
  public AudioSource Gs_Note;
  public Material highlightMaterial;
  public Material defaultMaterial;
  public GameObject Key;

  public void OnMouseDown()
  {
    Gs_Note.Play();
    ResetButton.KeysPlayed.Add("G#");
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
