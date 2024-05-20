using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Randomizer randomizer;
    public OuvreursMurs ouvreursMurs;
    public int score;
    private int niveau; // Declare niveau at class level
    private int nbOuvreurs;
    public float timeRemaining = 10;
    public bool binTimerDemarre = false;
    public Text timeText; // Assign your 'Chrono' Text object here in the Unity editor
    public Text scoreText; // Assign your 'Score' Text object here in the Unity editor
    public Text niveauText; // Assign your 'Niveau' Text object here in the Unity editor
    public Text ouvreurMurText; // Assign your 'OuvreurMur' Text object here in the Unity editor

    private void Start()
    {
        score = 300;
        niveau = randomizer.niveau;
        nbOuvreurs = ouvreursMurs.nbOuvreurs;
        UpdateScoreText();
        UpdateNiveauText();
        //UpdateOuvreurMurText();
    }

    void Update()
    {
        UpdateScoreText();
        if(nbOuvreurs != ouvreursMurs.nbOuvreurs)
        {
            UpdateOuvreurMurText();
        }
        if (binTimerDemarre)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                if (score > 200)
                {
                    print("Temps écoulé !");
                    score -= 200;
                    UpdateScoreText();
                }
                else
                {
                    // Handle game over state here
                }
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    void UpdateNiveauText()
    {
        niveauText.text = "Niveau : " + niveau.ToString(); // Use class level niveau variable
    }

    void UpdateOuvreurMurText()
    {
        score -= 50;
        nbOuvreurs = ouvreursMurs.nbOuvreurs;
        ouvreurMurText.text = "Ouvreurs de murs : " + nbOuvreurs.ToString();
    }
}