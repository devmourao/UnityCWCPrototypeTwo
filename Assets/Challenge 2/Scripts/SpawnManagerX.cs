using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{

    public bool gameOver = false;

    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;

    private float minSpawnInterval = 1.0f;
    private float maxSpawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomBallCoroutine());
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {

        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }


    private IEnumerator SpawnRandomBallCoroutine()
    {
        yield return new WaitForSeconds(startDelay);

        SpawnRandomBall();

        while (!gameOver)
        {
            float currentInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            yield return new WaitForSeconds(currentInterval);

            SpawnRandomBall();
        }
    }
}
