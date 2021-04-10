using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int numCrystals = 0;

    // void Start()
    // {
        
    // }

    // void Update()
    // {

    // }

    public void AcquireCrystal()
    {
        numCrystals++;
        // Play a crystal collection animation
    }

    public bool TakeACrystal()
    {
        if(numCrystals > 0)
        {
            numCrystals--;
            return true;
        }

        return false;
    }
}
