using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int numCrystals = 0;
    public int health = 100;
    public int maxSpecial = 25;
    public int special = 0;
    public bool canSpecial = false;
    public HealthBar healthBar;
    public SpecialBar specialBar;
    public GameState gameState;
    public Animator animator;

    void Start()
    {
        healthBar.SetMaxHealth(health);
        specialBar.SetMaxSpecial(maxSpecial);
        special = 0;
        gameState.player = this;
    }

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
        health -= damage - gameState.defenseBoost;
        healthBar.SetHealth(health);

        CinemachineShake.Instance.ShakeCamera(3, 0.1f);
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Play player death animation
        gameState.playerDead = true;
        animator.SetTrigger("IsDead");

        // and transition to death screen
    }

    public void GainSpeical(int specialGained)
    {
        special += specialGained;

        if(special <= maxSpecial)
        {
            specialBar.SetSpecial(special);
        }
        else
        {
            specialBar.SetSpecial(maxSpecial);
            canSpecial = true;
        }
    }

    public void UsedSpecial()
    {
        special = 0;
        canSpecial = false;
        specialBar.SetSpecial(special);
    }
    #endregion

}
