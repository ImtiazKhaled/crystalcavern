using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class SkullGirl : Enemy
{
    public Weapon weapon; 
    public Transform weaponPosition;
    Player playerObj;

    public override void Attack()
    {
        EnemyHit();
    }

    void EnemyHit()
    {
        // If the enemy is in the attack animation, don't attack
        // This makes the enemy attack physically if the player is within range of the enemy
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("SkullGirlAttack")) {
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);
            foreach(Collider2D player in hitPlayer)
            {
                TargetPlayer();
                animator.SetTrigger("IsAttacking");
                weapon.Shoot();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if(transform.position == null)
            return;

        Gizmos.DrawWireSphere(transform.position, attackRange);        

    }

    void TargetPlayer()
    {
        weaponPosition.right = currTargetPosition - transform.position;
    }
}
