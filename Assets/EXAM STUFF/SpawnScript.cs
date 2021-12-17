using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : LevelCommand
{
    public GameObject bird;
    public void Execute()
    {
        bird.GetComponent<BirdAI>().newStart();
        bird.SetActive(true);
        bird.transform.position = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 0f), 0);
    }

    public void Undo()
    {
        bird.SetActive(false);
    }


}
