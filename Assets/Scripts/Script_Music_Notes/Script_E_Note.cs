using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_E_Note : MonoBehaviour
{
    // Start is called before the first frame update
  public AudioSource E_Note;
  public Material highlightMaterial;
  public Material defaultMaterial;
  public GameObject Key;

  public void OnMouseDown()
  {
    E_Note.Play();
    ResetButton.KeysPlayed.Add("E");
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
