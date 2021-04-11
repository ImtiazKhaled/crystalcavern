using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int numCrystals = 0;
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
        gameState.playerDead = true;
        animator.SetTrigger("IsDead");
        Invoke("TransitionToDeathScreen", 5f);
    }

    void TransitionToDeathScreen()
    {
        SceneManager.LoadScene("Dead");
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
        CinemachineShake.Instance.ShakeCamera(5, 0.5f);
    }
    #endregion

}
