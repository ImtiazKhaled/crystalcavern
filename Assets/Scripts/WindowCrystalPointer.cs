using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCrystalPointer : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameState gameState;

    void Update()
    {
        List<Transform> crystalShardPositions = gameState.crystalShardLocations;
        Transform crystalPosition = gameState.crystalLocation;

        Vector2 pointDir = new Vector2(0, 0);


        for(int i = 0; i < crystalShardPositions.Count; i++)
        {
            if(crystalShardPositions[i] != null)
            {
                Vector2 currDist = new Vector2(crystalShardPositions[i].position.x, crystalShardPositions[i].position.y) - rb.position; 
    
                if(pointDir == new Vector2(0, 0))
                {
                    pointDir = currDist;
                }
                else
                {

                    if(currDist.magnitude < pointDir.magnitude)
                    {
                        pointDir = currDist;
                    }
                }
            }
            else
            {
                gameState.crystalShardLocations.RemoveAt(i);
            }
        }

        if(crystalShardPositions.Count == 0 & crystalPosition != null)
        {
            pointDir = new Vector2(crystalPosition.position.x, crystalPosition.position.y) - rb.position; 
        }

        float angle = Mathf.Atan2(pointDir.y, pointDir.x) * Mathf.Rad2Deg - 180f;
        rb.rotation = angle; 
    }
}
