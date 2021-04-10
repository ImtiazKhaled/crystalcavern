using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectileObj;
    public GameObject player;
    public Player playerObj;
    public Transform firepoint;
    public Animator animator;
    public float projectileForce = 20f;
    public Camera cam;
    public int specialDamage = 100;
    List<Enemy> visibleEnemies = new List<Enemy>();


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        else if(Input.GetButtonDown("Fire2") & playerObj.canSpecial)
        {
            Special();
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

    void Special()
    {
        playerObj.UsedSpecial();
        FindObjects();
    }

        // Find and store visible renderers to a list
    void FindObjects () 
    {
        // Retrieve all renderers in scene
        Enemy[] allEnemies = FindObjectsOfType<Enemy>();

        // Store only visible renderers
        visibleEnemies.Clear();
        for (int i = 0; i < allEnemies.Length; i++)
        {
            if (IsVisible(allEnemies[i]))
            {
                visibleEnemies.Add(allEnemies[i]);
            }
        }

        // deal damage to the enemies
        foreach (Enemy enemy in visibleEnemies)
        {
            enemy.SpecialHit(specialDamage);
        }
    }
 
    // Is the enemy within the main camera view?
    bool IsVisible(Enemy enemy) {
        Transform enemyPlacement = enemy.GetComponent<Transform>();
        Vector3 screenpos = cam.WorldToScreenPoint(enemyPlacement.position);
        bool offScreen = screenpos.x <= 0 
            || screenpos.x >= Screen.width
            || screenpos.y <= 0
            || screenpos.y >= Screen.height;

        return !offScreen;
    }
}
