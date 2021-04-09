using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    public Transform firepoint;
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
        // Spawn a projectile from the firepoint and add a force to it
        GameObject weapon = Instantiate(projectile, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();

        // Ignores collisions with player and gun
        Physics2D.IgnoreCollision(weapon.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        rb.AddForce(firepoint.right * projectileForce, ForceMode2D.Impulse);
    }
}
