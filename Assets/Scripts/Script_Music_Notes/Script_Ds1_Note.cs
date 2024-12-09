using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Ds1_Note : MonoBehaviour
{
  public AudioSource Ds1_Note;
  public Material highlightMaterial;
  public Material defaultMaterial;
  public GameObject Key;

  public void OnMouseDown()
  {
    Ds1_Note.Play();
    ResetButton.KeysPlayed.Add("D#1");
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
