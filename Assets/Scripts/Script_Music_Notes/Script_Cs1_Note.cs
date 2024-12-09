using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Cs1_Note : MonoBehaviour
{
  public AudioSource Cs1_Note;
  public Material highlightMaterial;
  public Material defaultMaterial;
  public GameObject Key;

  public void OnMouseDown()
  {
    Cs1_Note.Play();
    ResetButton.KeysPlayed.Add("C#1");
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
