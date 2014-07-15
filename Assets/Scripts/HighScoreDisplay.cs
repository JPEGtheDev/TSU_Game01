using UnityEngine;
using System.Collections;

public class HighScoreDisplay : MonoBehaviour
{
  public int No;
  TextMesh[] textMesh;

  void Start()
  {
    textMesh = GetComponentsInChildren<TextMesh>();

  }

  void Update()
  {
    textMesh[1].text = "" + (No + 1);
    if (valueStore.valStore.getScores(No) == 0)
      {
        textMesh[2].text = "";
      } else
      {
        textMesh[2].text = "" + valueStore.valStore.getScores(No);
      }		
    textMesh[0].text = valueStore.valStore.getNames(No);
  }
}
