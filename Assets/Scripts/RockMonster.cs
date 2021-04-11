using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class RockMonster : Enemy
{
    Player playerObj;
    public AudioClip rockyMonsterHit;

    public override void Attack()
    {
        EnemyHit();
    }

    void EnemyHit()
    {
        // If the enemy is in the attack animation, don't attack
        // This makes the enemy attack physically if the player is within range of the enemy
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("RockyMonsterAttack")) {
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);
            foreach(Collider2D player in hitPlayer)
            {
                playerObj = player.GetComponent<Player>();

                if(playerObj != null) 
                {
                    animator.SetTrigger("IsAttacking");
                    audioSource.PlayOneShot(rockyMonsterHit, 0.10f);
                    Invoke("DealDamage", 0.3f);
                }

            }
        }
    }

    void DealDamage()
    {
        playerObj.TakeDamage(enemyDamage);
        playerObj = null;
    }

    void OnDrawGizmosSelected()
    {
        if(transform.position == null)
            return;

        Gizmos.DrawWireSphere(transform.position, attackRange);        

    }
}
