using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Who spawning, where, and how often
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 14;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 3f;

    // For animals from left and right sides of the screen 
    private float sideSpawnMinZ = 0.0f;
    private float sideSpawnMaxZ = 16.0f;
    private float sideSpawnX = 19.0f;
    private float startDelaySideSpawn = 5;
    private float spawnIntervalSideSpawn = 4.5f;

    // Start is called before the first frame update
    // Invokes the method by it's name
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", startDelaySideSpawn, spawnIntervalSideSpawn);
        InvokeRepeating("SpawnRightAnimal", startDelaySideSpawn, spawnIntervalSideSpawn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // The method has randomized spawn position and animal selection
    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0 , 90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }

    void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }
}
