using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCrystalPointer : MonoBehaviour
{
    public Transform[] crystalShardPostions;
    public Transform crystalPosition;
    public Rigidbody2D rb;
    bool gotCrystals = false;
    void Update()
    {

        Vector2 pointDir = new Vector2(0, 0);

        if(!gotCrystals)
        {
            bool checkCrystals = true;

            for(int i = 0; i < crystalShardPostions.Length; i++)
            {
                if(crystalShardPostions[i] != null)
                {
                    Vector2 currDist = new Vector2(crystalShardPostions[i].position.x, crystalShardPostions[i].position.y) - rb.position; 
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
                    
                    checkCrystals = false;
                }
            }

            gotCrystals = checkCrystals;
        }

        if(gotCrystals)
        {
            pointDir = new Vector2(crystalPosition.position.x, crystalPosition.position.y) - rb.position; 
        }

        float angle = Mathf.Atan2(pointDir.y, pointDir.x) * Mathf.Rad2Deg - 180f;
        rb.rotation = angle;        
    }
}
