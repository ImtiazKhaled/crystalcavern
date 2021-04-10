using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public int crystalsNeeded = 3;
    int numCrystals = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        Debug.Log("Collided");
        if(player != null)
        {
            bool tookCrystal = player.TakeACrystal();

            if(tookCrystal)
            {
                numCrystals++;

                if(numCrystals == crystalsNeeded)
                {
                    Debug.Log("Got it bro");
                }
            }

        }
    }

    // void Start()
    // {
        
    // }

    // void Update()
    // {
        
    // }
}
