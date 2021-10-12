using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewChunk : MonoBehaviour
{
    public string direction = "left";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("TRIGGER ACTIVATED");
            WorldChunk thisChunk = transform.parent.parent.gameObject.GetComponent<WorldChunk>();
            if (direction == "left")
            {
                if (thisChunk.leftNeighbor == null)
                {
                    Debug.Log("Left neighbor is null");
                    thisChunk.leftNeighbor = WorldGen.instance.spawnChunk(transform);
                    thisChunk.leftNeighbor.rightNeighbor = thisChunk;
                }
            }
            else if (direction == "right")
            {
                if (thisChunk.rightNeighbor == null)
                {
                    thisChunk.rightNeighbor = WorldGen.instance.spawnChunk(transform);
                    thisChunk.rightNeighbor.leftNeighbor = thisChunk;
                }
            }
            else if (direction == "up")
            {
                if (thisChunk.upNeighbor == null)
                {
                    thisChunk.upNeighbor = WorldGen.instance.spawnChunk(transform);
                    thisChunk.upNeighbor.downNeighbor = thisChunk;
                }
            }
            else if (direction == "down")
            {
                if (thisChunk.downNeighbor == null)
                {
                    thisChunk.downNeighbor = WorldGen.instance.spawnChunk(transform);
                    thisChunk.downNeighbor.upNeighbor = thisChunk;
                }
            }
        }   
    }
}
