using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameState gameState;
    public int speicalGained = 25;


    #region Enemy Health
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public void SpecialHit(int damage)
    {
        health -= damage;
        // Play exploding animation

        // Delete the object if the health is zero
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        // otherwise let them return back to normal
    }

    void Die()
    {
        gameState.EnemyDied(speicalGained);
        // Play die animation here
        Destroy(gameObject);
    }
    #endregion
}
