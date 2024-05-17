using UnityEngine;
using System.Collections;

public class CameraJoueur : MonoBehaviour
{

    /*
    Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.  
    Converted to C# 27-02-13 - no credit wanted.
    Simple flycam I made, since I couldn't find any others made public.  
    Made simple to use (drag and drop, done) for regular keyboard layout  
    wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.  So camera doesn't gain any height*/


    private bool hasInstantiated = false;
    float mainSpeed = 3.0f; //regular speed
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;
    private bool binModeCarteActif;
    private Vector3 previousCameraPosition; //Position de la caméra avant de passer en mode carte
    private Quaternion previousCameraOrientation; //Orientation de l'object avant de passer en mode carte
    private GameObject pionJoueur;
    private int hauteurPionJoueur = 5;
    public GameObject murEnclos; // The wall object to spawn




    void Start()
    {
        pionJoueur = GameObject.Find("PionJoueur");
        pionJoueur.GetComponent<Renderer>().enabled = false;
        if (pionJoueur != null)
        {
            pionJoueur.transform.localPosition = new Vector3(0, hauteurPionJoueur, 0);
            pionJoueur.transform.eulerAngles = new Vector3(0, 45, 0);
        }
        else
        {
            Debug.LogError("PionJoueur object not found");
        }
    }
    void Update()
    {
        // print("Mode carte actif : " + binModeCarteActif);
        if ((Input.GetKeyDown(KeyCode.PageUp) || Input.GetKeyDown(KeyCode.Keypad9)) && !binModeCarteActif) //PageUp
        {
            pionJoueur.GetComponent<Renderer>().enabled = true;
            binModeCarteActif = true;
            ModeCarte();
        }
        else if ((Input.GetKeyDown(KeyCode.PageDown) || Input.GetKeyDown(KeyCode.Keypad3)) && binModeCarteActif) //PageDown
        {
            pionJoueur.GetComponent<Renderer>().enabled = false;
            binModeCarteActif = false;
            //Retour au jeu
            RetourModeJeu();
        }


        if (!binModeCarteActif) //Mode carte désactivé
        {
            if (pionJoueur != null)
            {
                Vector3 newPosition = transform.position;
                pionJoueur.transform.position = new Vector3(newPosition.x, hauteurPionJoueur, newPosition.z);
            }
            UpdatePositionCamera();
        }
        else //Mode carte activé
        {
            if (pionJoueur != null)
            {
                Vector3 newPosition = previousCameraPosition;
                pionJoueur.transform.position = new Vector3(newPosition.x, hauteurPionJoueur, newPosition.z);
            }
        }
        murEnclos = GameObject.Find("MurEnclos");
        if (!hasInstantiated && transform.position.x <= 13 && transform.position.z >= 15)
        {
            Instantiate(murEnclos, new Vector3(13, 1, 15), Quaternion.identity);
            hasInstantiated = true;
        }
    }

    private void UpdatePositionCamera()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        pionJoueur.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 45, 0); //suivre l'orientation de la caméra, +45 pour ajuster l'orientation du pion joueur
        //Mouse camera angle done.  

        //Keyboard commands
        Vector3 p = GetBaseInput();
        if (p.sqrMagnitude > 0)
        { // only move while a direction key is pressed


            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(p);
            }
            else
            { //If player wants to move on X and Z axis only
              //Si je joueur regarde directement vers le haut il ne se déplace plus
                p.y = 0; //On ne prend pas en compte les mouvements en hauteur ce qui permet de toujours se déplacer dans le plan XZ, comme si la camera était toujours à l'horizontale
                transform.Translate(p);
                newPosition.x = transform.position.x;
                newPosition.z = transform.position.z;
                transform.position = newPosition;
            }
        }
    }

    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }

    private void ModeCarte()
    {
        //perte de points quad utilise pageup

        // Sauvegarder la position de la caméra
        previousCameraPosition = transform.position;
        // Sauvegarder l'orientation de l'object
        previousCameraOrientation = transform.rotation;


        // Bouger la caméra au millieu en haut
        //Afficher la carte

        //Set la position de Joueur
        transform.position = new Vector3(15, 24, 15);
        //Set l'orientation de Joueur
        transform.rotation = Quaternion.Euler(90, -90, 0);
    }
    private void RetourModeJeu()
    {
        //Retour au jeu
        //Set la position de Joueur
        transform.position = previousCameraPosition;
        //Set l'orientation de Joueur
        transform.rotation = previousCameraOrientation;
    }
}