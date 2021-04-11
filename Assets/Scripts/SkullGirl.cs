using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class SkullGirl : Enemy
{
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public Transform attackPoint;
    Seeker seeker;
    Rigidbody2D rb;
    Transform enemyPosition;

    void EnemyHit()
    {
        // If the enemy is in the attack animation, don't attack
        // This makes the enemy attack physically if the player is within range of the enemy
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("SkullGirlAttack")) {
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
            foreach(Collider2D player in hitPlayer)
            {
                Player playerObj = player.GetComponent<Player>();

                if(playerObj != null) 
                {
                    animator.SetTrigger("IsAttacking");

                    // Play enemy attack animation here
                    playerObj.TakeDamage(enemyDamage);
                }

            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);        

    }
}
