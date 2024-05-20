using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public GameObject FlechePrefab;
    public GameObject TresorPrefab;
    public GameObject TeleTranspoPrefab;
    public GameObject TeleReceptPrefab;
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
        bool binPosOkFleche = false;
        int nbFleches = 18 - (niveau * 2);
        int posXFleche = 0;
        int posYFleche = 2;
        int posZFleche = 0;

        bool binPosTT = false;
        bool binPosTR = false;
        int nbTeleTransps = ((niveau + 1) / 2 | 0);
        int nbTeleRecepts = niveau;

        int posXTT = 0;
        int posYTT = 0;
        int posZTT = 0;
        int posXTR = 0;
        int posYTR = 0;
        int posZTR = 0;

        bool binPosOkTresor = false;
        int posXTresor = 0;
        float posYTresor = 0.3f;
        int posZTresor = 0;
        TresorPrefab = GameObject.Find("Tresor");

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
        if (TresorPrefab != null)
        {
            TresorPrefab.transform.localPosition = new Vector3(posXTresor, posYTresor, posZTresor);
        }
        // Vector3 positionsRandomTresor = new Vector3(posXTresor, posYTresor, posZTresor);
        // Instantiate(TresorPrefab, positionsRandomTresor, Quaternion.identity);

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
            GameObject fleche = Instantiate(FlechePrefab, positionsRandomFleche, Quaternion.identity);

            //Faire pointer la fleche vers le tresor
            Vector3 direction = TresorPrefab.transform.position - fleche.transform.position;
            direction.y = 0;
            fleche.transform.rotation = Quaternion.LookRotation(direction);
            i++;
        }

        int j = 0;
        while (j < nbTeleTransps)
        {
            binPosTT = false;
            while (binPosTT == false)
            {
                posXTT = (int)Mathf.Round(UnityEngine.Random.Range(0, 31));
                posZTT = (int)Mathf.Round(UnityEngine.Random.Range(0, 31));

                if (tabCarte[posXTT, posZTT] == v)
                {
                    binPosTT = true;
                    tabCarte[posXTT, posZTT] = V;
                }

            }
            Vector3 positionsRandomTT = new Vector3(posXTT, posYTT, posZTT);
            Instantiate(TeleTranspoPrefab, positionsRandomTT, Quaternion.identity);
            j++;
        }

        int k = 0;
        while (k < nbTeleRecepts)
        {
            binPosTR = false;
            while (binPosTR == false)
            {
                posXTR = (int)Mathf.Round(UnityEngine.Random.Range(0, 31));
                posZTR = (int)Mathf.Round(UnityEngine.Random.Range(0, 31));

                if (tabCarte[posXTR, posZTR] == v)
                {
                    binPosTR = true;
                    tabCarte[posXTR, posZTR] = V;
                }

            }
            Vector3 positionsRandomTR = new Vector3(posXTR, posYTR, posZTR);
            Instantiate(TeleReceptPrefab, positionsRandomTR, Quaternion.identity);
            k++;
        }
    }

}
