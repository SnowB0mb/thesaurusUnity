using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float RotationSpeed;
    
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        gameObject.transform.RotateAround(gameObject.transform.position, transform.forward, RotationSpeed);
    }
}
