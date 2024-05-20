using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    // Start is called before the first frame update
    public int dataScore; //Valeur du score, est remplis par le script UI
    public int dataNiveau; //Valeur du niveau, est remplis par le script UI
    public 
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
