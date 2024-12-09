using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
  public Material highlightMaterial;
  public Material defaultMaterial;
  public  GameObject RButton;
   public AudioSource Buzzer;

  public static int index;
  public static List<string> KeysPlayed = new List<string>();
  private static List<string> CorrectSequence = new List<string>();
    // Start is called before the first frame update
  public static bool equal;
  private void Start()
    {
      RButton.GetComponent<Renderer>().enabled = false;
      KeysPlayed = new List<string>();
      CorrectSequence = new List<string> {"E", "E", "E", "E", "E", "E", "E", "G", "C", "D", "E"};
      index = -1;
      // CorrectSequence = new List<string> {"E", "E", "E", "E", "E", "E", "E", "G", "C", "D", "E",
      // "F", "F", "F", "F", "F", "E", "E", "E", "E", "G", "G", "F", "D", "C"};
    }

  private void Update()
    {
    if (index != -1 && KeysPlayed[index] != CorrectSequence[index])
    {
      index = -1;
      KeysPlayed = new List<string>();
      Buzzer.Play();

    }
    if (KeysPlayed.SequenceEqual(CorrectSequence))
    {
      RButton.GetComponent<Renderer>().enabled = true;
    }
  }
  public void OnMouseDown()
  {
    KeysPlayed.Clear();
  }
  public void OnHoverEnter()
  {
    RButton.GetComponent<Renderer>().material = highlightMaterial;
  }

  public void OnHoverExit()
  {
     RButton.GetComponent<Renderer>().material = defaultMaterial;
  }
}
