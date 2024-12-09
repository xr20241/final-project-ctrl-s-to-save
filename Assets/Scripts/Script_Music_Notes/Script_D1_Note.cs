using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_D1_Note : MonoBehaviour
{
  public AudioSource D1_Note;
  public Material highlightMaterial;
  public Material defaultMaterial;
  public GameObject Key;

  public void OnMouseDown()
  {
    D1_Note.Play();
    ResetButton.KeysPlayed.Add("D1");
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
