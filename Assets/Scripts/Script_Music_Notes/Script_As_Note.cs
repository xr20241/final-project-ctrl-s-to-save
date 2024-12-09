using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_As_Note : MonoBehaviour
{
  public AudioSource As_Note;
  public Material highlightMaterial;
  public Material defaultMaterial;
  public GameObject Key;

  public void OnMouseDown()
  {
    As_Note.Play();
    ResetButton.KeysPlayed.Add("A#");
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
