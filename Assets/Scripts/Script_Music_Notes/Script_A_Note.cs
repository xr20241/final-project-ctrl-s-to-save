using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Script_A_Note : MonoBehaviour
{
  public AudioSource A_Note;
  public Material highlightMaterial;
  public Material defaultMaterial;
  public GameObject Key;
  public List<string> KeysPlayed = new List<string>();

  ResetButton rb;

  public void OnMouseDown()
  {
    A_Note.Play();
    ResetButton.KeysPlayed.Add("A");
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
