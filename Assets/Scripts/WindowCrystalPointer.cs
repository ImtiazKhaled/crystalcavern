using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCrystalPointer : MonoBehaviour
{
    public Transform crystalPosition;
    public Rigidbody2D rb;
    public GameState gameState;

    void Update()
    {
        List<Transform> crystalShardPositions = gameState.crystalLocations;

        Vector2 pointDir = new Vector2(0, 0);
        Debug.Log(gameState.crystalLocations);


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
                gameState.crystalLocations.RemoveAt(i);
            }
        }

        if(crystalShardPositions.Count == 0)
        {
            pointDir = new Vector2(crystalPosition.position.x, crystalPosition.position.y) - rb.position; 
        }

        float angle = Mathf.Atan2(pointDir.y, pointDir.x) * Mathf.Rad2Deg - 180f;
        rb.rotation = angle;        
    }
}
