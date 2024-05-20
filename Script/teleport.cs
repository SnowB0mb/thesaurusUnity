using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    CameraJoueur playerController;
    private bool canTeleport;
    private GameObject lastTeleRecept; //Dernier recept utilisé

    void Awake() 
    {
        canTeleport = true;
        playerController = GetComponent<CameraJoueur>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (canTeleport && (other.CompareTag("TeleTransp") || other.CompareTag("TeleRecept")))
        {
            StartCoroutine(TeleportCoroutine(other.gameObject));
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TeleRecept"))
        {
            canTeleport = true;
        }
    }

    IEnumerator TeleportCoroutine(GameObject teleRecept)
    {
        canTeleport = false;
            playerController.enabled = false;
        yield return new WaitForSeconds(0.1f);

        List<GameObject> possibleDestinations = new List<GameObject>();
        GameObject[] destinations = GameObject.FindGameObjectsWithTag("TeleRecept");
        foreach (GameObject destination in destinations)
        {
            if (destination != lastTeleRecept)
            {
                possibleDestinations.Add(destination);
            }
        }

        if (possibleDestinations.Count > 0)
        {
            int randomIndex = Random.Range(0, possibleDestinations.Count);
            GameObject randomDestination = possibleDestinations[randomIndex];
            
            Vector3 newPosition = randomDestination.transform.position;
            newPosition.y += 1.0f;
            transform.position = newPosition;
        }

        lastTeleRecept = teleRecept;

        yield return new WaitForSeconds(0.1f);
        playerController.enabled = true;
    }
}
