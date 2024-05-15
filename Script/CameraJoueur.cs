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


    float mainSpeed = 3.0f; //regular speed
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;
    private bool binModeCarteActif;
    private Vector3 previousCameraPosition; //Position de la caméra avant de passer en mode carte
    private Quaternion previousCameraOrientation; //Orientation de l'object avant de passer en mode carte
    private GameObject pionJoueur;

    void Start()
    {
        pionJoueur = GameObject.Find("Tresor");
        if (pionJoueur != null)
        {
            pionJoueur.transform.SetParent(transform);
            pionJoueur.transform.localPosition = new Vector3(0, 1, 0); // Adjust this value to set the height above the camera
        }
        else
        {
            Debug.LogError("Tresor object not found");
        }
    }
    void Update()
    {
        // print("Mode carte actif : " + binModeCarteActif);
        if (Input.GetKeyDown(KeyCode.PageUp) && !binModeCarteActif)
        {
            binModeCarteActif = true;
            ModeCarte();
            if (pionJoueur != null)
            {
                pionJoueur.transform.SetParent(null);
            }
        }
        else if (Input.GetKeyDown(KeyCode.PageDown) && binModeCarteActif)
        {
            binModeCarteActif = false;
            //Retour au jeu
            RetourModeJeu();
            if (pionJoueur != null)
            {
                pionJoueur.transform.SetParent(transform);
            }
        }


        if (!binModeCarteActif)
        {
            if (pionJoueur != null)
            {
                Vector3 newPosition = transform.position;
                Quaternion newRotation = transform.rotation;
                pionJoueur.transform.position = new Vector3(newPosition.x, 5, newPosition.z);
                pionJoueur.transform.rotation = Quaternion.Euler(0, newRotation.y, 0);
            }
            UpdatePositionCamera();
        }
        else
        {
            if (pionJoueur != null)
            {
                Vector3 newPosition = previousCameraPosition;
                Quaternion newRotation = previousCameraOrientation;
                pionJoueur.transform.position = new Vector3(newPosition.x, 5, newPosition.z);
                pionJoueur.transform.rotation = Quaternion.Euler(0, newRotation.y, 0);
            }
        }
    }

    private void UpdatePositionCamera()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        //Mouse  camera angle done.  

        //Keyboard commands
        Vector3 p = GetBaseInput();
        if (p.sqrMagnitude > 0)
        { // only move while a direction key is pressed


            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            if (Input.GetKey(KeyCode.Space))
            { //If player wants to move on X and Z axis only
                transform.Translate(p);
            }
            else
            {
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
        transform.rotation = Quaternion.Euler(90, 0, 0);
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