using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    public int score;
    public GUIStyle scoreStyle;
    public float timeRemaining = 10;
    public bool binTimerDemarre = false;
    public string timeText;

    private void Start()
    {
        score = 300; // Initialize score here instead of OnGUI
    }
    private void OnGUI()
    {
        score = 300;
        DisplayTime(timeRemaining);
        GUI.Label(new Rect(10, 10, 100, 100), timeText.ToString(), scoreStyle);
        GUI.Label(new Rect(110, 10, 100, 100), score.ToString(), scoreStyle);

    }

    void Update()
    {
        DisplayTime(timeRemaining);
        if (binTimerDemarre)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                // binTimerDemarre = false;
                //Terminer le jeu
                if (score > 200) //le jeu continue, le joueur doit recommerncer le niveau
                {
                    score -= 200;
                }
                else //le joueur à perdu c'est Game Over
                {

                }
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
