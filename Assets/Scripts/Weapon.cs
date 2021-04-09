using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectileObj;
    public GameObject player;
    public Transform firepoint;
    public Animator animator;
    public float projectileForce = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("BowShooting")) {
            animator.SetTrigger("IsShooting");
            // Spawn a projectile from the firepoint and add a force to it
            GameObject projectile = Instantiate(projectileObj, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // Ignores collisions with player and gun
            Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
            rb.AddForce(firepoint.right * projectileForce, ForceMode2D.Impulse);
        }
    }
}
