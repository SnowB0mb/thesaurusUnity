using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public GameObject FlechePrefab;
    public GameObject TresorPrefab;

    public int niveau = 0;

    public const char m = 'm';
    public const char v = 'v';
    public const char d = 'd';
    public const char c = 'c';
    public const char s = 's';
    public const char j = 'j';
    public const char V = 'V';

    char[,] tabCarte = {
            {m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m},
            {m, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, m},
            {m, v, d, d, d, d, d, d, v, d, d, d, d, d, v, d, v, d, d, d, d, d, v, d, d, d, d, d, d, v, m},
            {m, v, v, v, v, v, v, v, v, d, v, v, v, d, v, d, v, d, v, v, v, d, v, v, v, v, v, v, v, v, m},
            {m, d, d, d, d, d, d, d, v, d, d, v, d, d, v, d, v, d, d, v, d, d, v, d, d, d, d, d, d, d, m},
            {m, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, m},
            {m, d, d, d, v, d, d, d, v, d, v, d, d, d, v, d, v, d, d, d, v, d, v, d, d, d, v, d, d, d, m},
            {m, v, v, v, v, v, v, v, v, d, v, d, v, d, v, d, v, d, v, d, v, d, v, v, v, v, v, v, v, v, m},
            {m, d, d, d, v, d, d, d, v, d, v, d, v, d, v, d, v, d, v, d, v, d, v, d, d, d, v, d, d, d, m},
            {m, v, v, v, v, v, v, v, v, d, v, d, v, d, v, d, v, d, v, d, v, d, v, v, v, v, v, v, v, v, m},
            {m, v, d, d, d, d, d, d, v, d, v, d, v, d, v, d, v, d, v, d, v, d, v, d, d, d, d, d, d, v, m},
            {m, v, v, v, v, v, v, d, v, d, d, d, v, d, v, d, v, d, v, d, d, d, v, d, v, v, v, v, v, v, m},
            {m, d, d, d, d, d, v, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, v, d, d, d, d, d, m},
            {m, v, v, v, v, v, v, d, v, d, d, d, v, c, c, s, c, c, v, d, d, d, v, d, v, v, v, v, v, v, m},
            {m, v, d, d, d, d, d, d, v, d, v, d, v, c, j, j, j, c, v, d, v, d, v, d, d, d, d, d, d, v, m},
            {m, v, v, v, v, v, v, v, v, d, v, d, v, c, j, j, j, c, v, d, v, d, v, v, v, v, v, v, v, v, m},
            {m, d, d, d, d, d, d, d, v, d, v, d, v, c, j, j, j, c, v, d, v, d, v, d, d, d, d, d, d, d, m},
            {m, v, v, v, v, v, v, v, v, d, v, d, v, c, c, c, c, c, v, d, v, d, v, v, v, v, v, v, v, v, m},
            {m, v, d, d, d, d, d, d, v, d, v, d, v, v, v, v, v, v, v, d, v, d, v, d, d, d, d, d, d, v, m},
            {m, v, d, v, v, v, v, v, v, d, v, d, d, d, d, v, d, d, d, d, v, d, v, v, v, v, v, v, d, v, m},
            {m, v, d, v, d, d, d, d, v, d, v, v, v, v, d, v, d, v, v, v, v, d, v, d, d, d, d, v, d, v, m},
            {m, v, d, v, d, v, v, v, v, d, v, d, v, v, d, v, d, v, v, d, v, d, v, v, v, v, d, v, d, v, m},
            {m, v, d, v, d, d, d, d, v, d, v, d, v, d, d, v, d, d, v, d, v, d, v, d, d, d, d, v, d, v, m},
            {m, v, v, v, v, v, v, d, v, d, v, v, v, d, v, v, v, d, v, v, v, d, v, d, v, v, v, v, v, v, m},
            {m, v, d, d, d, d, v, d, v, d, v, d, d, d, v, d, v, d, d, d, v, d, v, d, v, d, d, d, d, v, m},
            {m, v, v, v, v, v, v, d, v, v, v, d, v, v, v, v, v, v, v, d, v, v, v, d, v, v, v, v, v, v, m},
            {m, v, d, v, d, d, v, d, v, d, d, d, v, d, d, v, d, d, v, d, d, d, v, d, v, d, d, v, d, v, m},
            {m, v, d, v, d, v, v, d, v, d, v, v, v, d, v, v, v, d, v, v, v, d, v, d, v, v, d, v, d, v, m},
            {m, d, d, v, d, d, d, d, v, d, v, d, d, d, d, d, d, d, d, d, v, d, v, d, d, d, d, v, d, d, m},
            {m, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, m},
            {m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m, m}
    };

    // Start is called before the first frame update
    void Start()
    {
        FlechePrefab = GameObject.Find("Fleche");
        TresorPrefab = GameObject.Find("Tresor");
        MurEnclorPrefab = GameObject.Find("MurEnclos");
        bool binPosOkFleche = false;
        int posXFleche = 0;
        int posYFleche = 2;
        int posZFleche = 0;

        int nbFleches = 18 - (niveau * 2);
        int nbTeleTransps = ((niveau + 1) / 2 | 0);
        int nbTeleRecepts = niveau;

        int i = 0;
        while (i < nbFleches)
        {
            binPosOkFleche = false;
            while (binPosOkFleche == false)
            {
                posXFleche = (int)Mathf.Round(UnityEngine.Random.Range(0, 31));
                posZFleche = (int)Mathf.Round(UnityEngine.Random.Range(0, 31));

                if (tabCarte[posXFleche, posZFleche] == v)
                {
                    binPosOkFleche = true;
                    tabCarte[posXFleche, posZFleche] = V;
                }

            }
            Vector3 positionsRandomFleche = new Vector3(posXFleche, posYFleche, posZFleche);
            Instantiate(FlechePrefab, positionsRandomFleche, Quaternion.identity);
            i++;
        }
3
        bool binPosOkTresor = false;
        int posXTresor = 0;
        int posYTresor = 3;
        int posZTresor = 0;

        while (binPosOkTresor == false)
        {
            posXTresor = (int)Mathf.Round(UnityEngine.Random.Range(0, 31));
            posZTresor = (int)Mathf.Round(UnityEngine.Random.Range(0, 31));

            if (tabCarte[posXTresor, posZTresor] == v)
            {
                binPosOkTresor = true;
                tabCarte[posXTresor, posZTresor] = V;
            }

        }
        Vector3 positionsRandomTresor = new Vector3(posXTresor, posYTresor, posZTresor);
        Instantiate(TresorPrefab, positionsRandomTresor, Quaternion.identity);
    }

}
