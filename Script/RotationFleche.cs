using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFleche : MonoBehaviour
{
    public float RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Rotation fleche sur elle-même
        gameObject.transform.RotateAround(gameObject.transform.position, transform.forward, RotationSpeed);
        
        //Faire pointer la fleche vers le tresor
        GameObject tresor = GameObject.Find("Tresor");
        if (tresor != null)
        {
            Vector3 direction = tresor.transform.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
