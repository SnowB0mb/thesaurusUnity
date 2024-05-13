using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class wallSpawn : MonoBehaviour
{
    public GameObject murExterieur; // The wall object to spawn
    public GameObject murInterieur; // The wall object to spawn
    public char[,] map; // The 2'd' array representing the map

    private void Start()
    {
        map = new char[,] {
            {'m', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm'},
            {'m', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'm'},
            {'m', 'v', 'd', 'd', 'd', 'd', 'd', 'd', 'v', 'd', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'd', 'v', 'd', 'd', 'd', 'd', 'd', 'd', 'v', 'm'},
            {'m', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'v', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'v', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'm'},
            {'m', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'v', 'd', 'd', 'v', 'd', 'd', 'v', 'd', 'v', 'd', 'd', 'v', 'd', 'd', 'v', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'm'},
            {'m', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'm'},
            {'m', 'd', 'd', 'd', 'v', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'v', 'd', 'd', 'd', 'm'},
            {'m', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'm'},
            {'m', 'd', 'd', 'd', 'v', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'v', 'd', 'd', 'd', 'm'},
            {'m', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'm'},
            {'m', 'v', 'd', 'd', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'd', 'd', 'v', 'm'},
            {'m', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'm'},
            {'m', 'd', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'd', 'm'},
            {'m', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'd', 'd', 'v', 'c', 'c', 's', 'c', 'c', 'v', 'd', 'd', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'm'},
            {'m', 'v', 'd', 'd', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'v', 'c', 'j', 'j', 'j', 'c', 'v', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'd', 'd', 'v', 'm'},
            {'m', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'v', 'c', 'j', 'j', 'j', 'c', 'v', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'm'},
            {'m', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'v', 'c', 'j', 'j', 'j', 'c', 'v', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'm'},
            {'m', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'v', 'c', 'c', 'c', 'c', 'c', 'v', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'm'},
            {'m', 'v', 'd', 'd', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'd', 'd', 'v', 'm'},
            {'m', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'v', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'm'},
            {'m', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'm'},
            {'m', 'v', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'v', 'v', 'd', 'v', 'd', 'v', 'v', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'v', 'm'},
            {'m', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'd', 'v', 'd', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'm'},
            {'m', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'd', 'v', 'v', 'v', 'd', 'v', 'v', 'v', 'd', 'v', 'v', 'v', 'd', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'm'},
            {'m', 'v', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'v', 'm'},
            {'m', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'v', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'd', 'v', 'v', 'v', 'd', 'v', 'v', 'v', 'v', 'v', 'v', 'm'},
            {'m', 'v', 'd', 'v', 'd', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'v', 'd', 'd', 'v', 'd', 'd', 'v', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'd', 'v', 'd', 'v', 'm'},
            {'m', 'v', 'd', 'v', 'd', 'v', 'v', 'd', 'v', 'd', 'v', 'v', 'v', 'd', 'v', 'v', 'v', 'd', 'v', 'v', 'v', 'd', 'v', 'd', 'v', 'v', 'd', 'v', 'd', 'v', 'm'},
            {'m', 'd', 'd', 'v', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'v', 'd', 'v', 'd', 'd', 'd', 'd', 'v', 'd', 'd', 'm'},
            {'m', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'm'},
            {'m', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm', 'm'}
        };

        // Loop through the 2d array
        murExterieur = GameObject.Find("MurExterieur"); // Assign the GameObject
        murInterieur = GameObject.Find("MurInterieur"); // Assign the GameObject

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                // Check if the current element is 'd'
                if (map[i, j] == 'd')
                {
                    // Spawn a wall object at the i,j coordinates
                    Instantiate(murExterieur, new Vector3(i, 0, j), Quaternion.identity);
                }
                //Check if the current element is 'm' or 'j'
                else if (map[i, j] == 'm' || map[i, j] == 'c')
                {
                    // Spawn a wall object at the i,j coordinates
                    Instantiate(murInterieur, new Vector3(i, 0, j), Quaternion.identity);
                }
            }
        }
    }
}

