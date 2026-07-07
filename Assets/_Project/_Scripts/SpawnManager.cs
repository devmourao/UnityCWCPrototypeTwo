using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public InputAction spawnAction;

    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    private float startDelay = 2;
    public float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        spawnAction.Enable();
    }

    void Update()
    {
        if (spawnAction.triggered)
        {
           SpawnRandomAnimal();
        }
    }

    void SpawnRandomAnimal()
    {
        // Randomly generate animal index and spawn position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),
        0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos,
        animalPrefabs[animalIndex].transform.rotation);
    }
}