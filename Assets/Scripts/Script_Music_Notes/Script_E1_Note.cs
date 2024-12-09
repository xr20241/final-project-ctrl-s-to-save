using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_E1_Note : MonoBehaviour
{
    // Start is called before the first frame update
  public AudioSource E1_Note;
  public Material highlightMaterial;
  public Material defaultMaterial;
  public GameObject Key;

  public void OnMouseDown()
  {
    E1_Note.Play();
    ResetButton.KeysPlayed.Add("E1");
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
