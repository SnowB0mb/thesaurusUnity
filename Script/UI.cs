using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public int score;
    public GUIStyle scoreStyle;
   private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), score.ToString(), scoreStyle);
    }
}
