using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeverAnswer : MonoBehaviour
{
  public  GameObject Answer;
  public static List<string> LeverSequence = new List<string>();
  private static List<string> CorrectSequence = new List<string>();
    // Start is called before the first frame update
  public static bool equal;
  private void Start()
    {
      Answer.GetComponent<Renderer>().enabled = false;
      LeverSequence = new List<string>{"Up", "Up", "Up", "Up"};
      CorrectSequence = new List<string> {"Up", "Up", "Down", "Down"};
    }

  private void Update()
    {
    if (LeverSequence.SequenceEqual(CorrectSequence))
    {
      Answer.GetComponent<Renderer>().enabled = true;
    }
    else
    {
      Answer.GetComponent<Renderer>().enabled = false;
    }
  }
}
