using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spRangeX = 20;
    private float spPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        //Spawns random animal once in 1.5seconds.
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);    
    }
    
    // Update is called once per frame
    void Update()
    {
       

    }
    void SpawnRandomAnimal()
    {
        //Animal spawn area.
        Vector3 spawnPos = new Vector3(Random.Range(-spRangeX, spRangeX), 0, spPosZ);
        //Randomizes animal spawn location, sets animals facing the player.
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);

    }
}
