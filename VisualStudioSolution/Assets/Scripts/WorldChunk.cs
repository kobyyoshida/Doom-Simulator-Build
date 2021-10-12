using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WorldChunk : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public Transform[] obstacleSpawnPoints;
    public WorldChunk leftNeighbor = null;
    public WorldChunk rightNeighbor = null;
    public WorldChunk upNeighbor = null;
    public WorldChunk downNeighbor = null;



    public void spawnEnemies()
    {
        foreach(Transform pos in enemySpawnPoints)
        {
            int enemyType = Random.Range(0, WorldGen.instance.enemies.Length);
            GameObject newEnemy = Instantiate(WorldGen.instance.enemies[enemyType], transform);
            newEnemy.transform.position = pos.position;
        }
    }

    public void spawnObstacles()
    {
        foreach(Transform pos in obstacleSpawnPoints)
        {
            int obType = Random.Range(0, WorldGen.instance.obstacles.Length);
            GameObject newOb = Instantiate(WorldGen.instance.obstacles[obType], transform);
            newOb.transform.position = pos.position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
