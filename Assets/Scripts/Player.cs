using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int numCrystals = 0;
    public int health = 100;

    #region Crystals
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
    #endregion

    #region EnemyInteractions
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Play player death animation
        // and transition to death screen
    }
    #endregion

}
