using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectileObj;
    public Transform firepoint;
    public Animator animator;
    public float projectileForce = 20f;
    public GameObject caster;

    public void Shoot()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("BowShooting")) {
            animator.SetTrigger("IsShooting");
            // Spawn a projectile from the firepoint and add a force to it
            GameObject projectile = Instantiate(projectileObj, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            
            Projectile projectileInstance = projectile.GetComponent<Projectile>();

            // Set projectile to damage player not enemies
            if(projectileInstance != null & caster.name != "Player")
            {
                projectileInstance.playerAttack = false;
            }

            // Ignores collisions with caster and collision
            Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), caster.GetComponent<Collider2D>());
            rb.AddForce(firepoint.right * projectileForce, ForceMode2D.Impulse);
        }
    }
}
