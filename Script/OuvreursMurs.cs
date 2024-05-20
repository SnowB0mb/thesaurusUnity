using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class OuvreursMurs : MonoBehaviour
{
    public Randomizer randomizer;
    public UI ui;
    public float raycastDistance = 1.5f; // Distance maximum du raycast
    private int niveau;
    private int score;
    public int nbOuvreurs;

    void Start()
    {
        niveau = randomizer.niveau;
        score = ui.score;
        nbOuvreurs = 4 - (niveau / 2 | 0);
    }

    // Update is called once per frame
    void Update()
    {
        score = ui.score;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (nbOuvreurs > 0 && score > 50)
            {
                //if (intScore >= 50)
                {
                    //objSons.briseMur.play();

                    // Obtenir la cam�ra principale
                    Camera mainCamera = Camera.main;
                    if (mainCamera != null)
                    {
                        // Position de d�part du raycast (position de la cam�ra)
                        Vector3 origin = mainCamera.transform.position;
                        // Direction du raycast (direction dans laquelle la cam�ra regarde)
                        Vector3 direction = mainCamera.transform.forward;

                        // Lancer un raycast
                        RaycastHit hit;
                        if (Physics.Raycast(origin, direction, out hit, raycastDistance))
                        {
                            // V�rifier si l'objet touch� a un tag "Wall"
                            if (hit.collider.CompareTag("MurInterieur"))
                            {
                                // D�truire l'objet touch�
                                Destroy(hit.collider.gameObject);
                                nbOuvreurs--;
                                //intScore -= 50;
                                UnityEngine.Debug.Log("Mur d�truit !");
                            }
                        }
                    }
                }
            }
            else
            {
                UnityEngine.Debug.Log("Vous n'avez plus d'ouvreurs de murs...");
            }
        }

    }
}
