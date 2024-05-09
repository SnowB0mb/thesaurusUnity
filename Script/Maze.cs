using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public Maze mazePrefab;
    private Maze mazeInstance;

    private void BeginGame(){
        mazeInstance = Instantiate(mazePrefab) as Maze;
    }

    private void RestartGame(){
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }
}
