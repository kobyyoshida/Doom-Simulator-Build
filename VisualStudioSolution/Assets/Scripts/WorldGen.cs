using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WorldGen : MonoBehaviour
{
    public GameObject startChunk;
    public GameObject bossChunk;
    public GameObject shopChunk;
    public GameObject[] worldChunks;
    public GameObject[] enemies;
    public GameObject[] obstacles;
    public static WorldGen instance;
    public List<WorldChunk> loadedChunks;
    public int chunkCount = 0;


    private void Awake()
    {
        instance = this;
        loadedChunks.Add(startChunk.GetComponent<WorldChunk>());
    }


    public WorldChunk spawnChunk(Transform spawnPoint)
    {
        GameObject newChunkObject;
        if (loadedChunks.Count % 5 == 0)
        {
            newChunkObject = Instantiate(shopChunk, spawnPoint);
        } else if (loadedChunks.Count % 7 == 0)
        {
            newChunkObject = Instantiate(bossChunk, spawnPoint);
        } else
        {
            //Debug.Log("IN spawnChunk method");
            int randNum = Random.Range(0, worldChunks.Length);
            //Debug.Log(randNum);
            newChunkObject = Instantiate(worldChunks[randNum], spawnPoint);
        }
        
        newChunkObject.transform.SetParent(transform);
        WorldChunk newChunk = newChunkObject.GetComponent<WorldChunk>();
        foreach (WorldChunk chunk in loadedChunks)
        {
            if (newChunkObject.transform.position.x == chunk.gameObject.transform.position.x)
            {
                if (newChunkObject.transform.position.y + 16 == chunk.gameObject.transform.position.y)
                {
                    newChunk.upNeighbor = chunk;
                    chunk.downNeighbor = newChunk;
                    continue;
                }
                if (newChunkObject.transform.position.y - 16 == chunk.gameObject.transform.position.y)
                {
                    newChunk.downNeighbor = chunk;
                    chunk.upNeighbor = newChunk;
                    continue;
                }

            }
            if (newChunkObject.transform.position.y == chunk.gameObject.transform.position.y)
            {
                if (newChunkObject.transform.position.x + 16 == chunk.gameObject.transform.position.x)
                {
                    newChunk.rightNeighbor = chunk;
                    chunk.leftNeighbor = newChunk;
                    continue;
                }
                if (newChunkObject.transform.position.x - 16 == chunk.gameObject.transform.position.x)
                {
                    newChunk.leftNeighbor = chunk;
                    chunk.rightNeighbor = newChunk;
                    continue;
                }

            }
        }
        loadedChunks.Add(newChunk);
        newChunk.spawnEnemies();
        newChunk.spawnObstacles();
        chunkCount++;/*
         int enemyCount = Random.Range(1, 4);
         int[] enemyPositions = new int[enemyCount]; 
         for(int i = 0; i < enemyCount; i++)
         {
             int enemyPos = Random.Range(0, newChunk.enemySpawnPoints.Length - 1);
             while (enemyPositions.Contains<int>(enemyPos))
             {
                 enemyPos = Random.Range(0, newChunk.enemySpawnPoints.Length - 1);
             }
             enemyPositions[i] = enemyPos;
             int enemyType = Random.Range(0, enemies.Length - 1);
             GameObject newEnemy = Instantiate(enemies[enemyType], newChunk.enemySpawnPoints[enemyPos]);
             //Debug.Log("Enemy Spawned at: " + newChunk.enemySpawnPoints[enemyPos].position.x + " " + newChunk.enemySpawnPoints[enemyPos].position.y + " " + newChunk.enemySpawnPoints[enemyPos].position.z);
         }

         int obstacleCount = Random.Range(2, 5);
         int[] obstaclePositions = new int[obstacleCount];

         for (int i = 0; i < obstacleCount; i++)
         {
             int obstaclePos = Random.Range(0, newChunk.obstacleSpawnPoints.Length - 1);
             while (obstaclePositions.Contains<int>(obstaclePos))
             {
                 obstaclePos = Random.Range(0, newChunk.obstacleSpawnPoints.Length - 1);
             }
             obstaclePositions[i] = obstaclePos;
             int obstacleType = Random.Range(0, obstacles.Length - 1);
             GameObject newObstacle = Instantiate(obstacles[obstacleType], newChunk.obstacleSpawnPoints[obstaclePos]);
         }*/
        return newChunk;
    }

}
