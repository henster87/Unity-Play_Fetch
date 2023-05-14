using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private int spawnIntervalMin = 3;
    private int spawnIntervalMax = 5;

    public static int timer = 1;
    private float timerCopy = timer;

    // Start is called before the first frame update
    void Update() 
    {
        RandomBallSpawnTimer();
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

    void RandomBallSpawnTimer()
    {
        // Reduce timercopy every second
        timerCopy -= Time.deltaTime;

        // When timercopy reaches 0, set timer to a random number and spawn a new ball
        if (timerCopy < 0)
        {
            SpawnRandomBall();
            int timer = Random.Range(spawnIntervalMin, spawnIntervalMax);
            timerCopy = timer;
        }
    }

}
