using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_D_Note : MonoBehaviour
{
  public AudioSource D_Note;
  public Material highlightMaterial;
  public Material defaultMaterial;
  public GameObject Key;

  public void OnMouseDown()
  {
    D_Note.Play();
    ResetButton.KeysPlayed.Add("D");
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
