using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Randomizer randomizer;
    public OuvreursMurs ouvreursMurs;
    public CameraJoueur cameraJoueur;
    public int score;
    private int niveau; // Declare niveau at class level
    private int nbOuvreurs;
    private bool binModeCarteActif;
    private bool binCollisionTresor;
    public float timeRemaining = 30;
    public bool binTimerDemarre = false;
    public Text timeText; // Assign your 'Chrono' Text object here in the Unity editor
    public Text scoreText; // Assign your 'Score' Text object here in the Unity editor
    public Text niveauText; // Assign your 'Niveau' Text object here in the Unity editor
    public Text ouvreurMurText; // Assign your 'OuvreurMur' Text object here in the Unity editor
    private bool finJeu = false;

    private void Start()
    {
        score = 300;
        niveau = randomizer.niveau;
        nbOuvreurs = ouvreursMurs.nbOuvreurs;
        binModeCarteActif = cameraJoueur.binModeCarteActif;
        binCollisionTresor = cameraJoueur.binCollisionTresor;
        UpdateScoreText();
        UpdateNiveauText();
        UpdateOuvreurMurText();
        InvokeRepeating("DiminueScoreCarte", 1.0f, 1.0f);
    }

    void Update()
    {
        binCollisionTresor = cameraJoueur.binCollisionTresor;
        UpdateScoreText();
        if (nbOuvreurs != ouvreursMurs.nbOuvreurs)
        {
            UpdateOuvreurMurText();
        }
        if (binTimerDemarre)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);

               
                if (binCollisionTresor && !finJeu) //touche le trésor, gagne le niveau
                {
                    finJeu = true;
                    score += Mathf.CeilToInt(10 * timeRemaining);
                    
                    DataStorage dataStorage = GetComponent<DataStorage>();
                    dataStorage.dataScore = score;
                    dataStorage.dataNiveau = niveau;
                    //Changer de niveau
                    //Remettre le joueur au milieu et replacer les objets
                }
            }
            else
            {
                timeRemaining = 0;
                if (score > 200)
                {
                    print("Temps écoulé !");
                    score -= 200;
                    UpdateScoreText();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reset the scene
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
        if (nbOuvreurs != ouvreursMurs.nbOuvreurs)
        {
            score -= 50;
        }
        nbOuvreurs = ouvreursMurs.nbOuvreurs;
        ouvreurMurText.text = "Ouvreurs de murs : " + nbOuvreurs.ToString();
    }

    void DiminueScoreCarte()
    {
        if (cameraJoueur.binModeCarteActif)
        {
            score -= 10;
            UpdateScoreText();
        }
    }
}