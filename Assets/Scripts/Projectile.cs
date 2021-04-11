using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject collisionEffect;
    public float collisionDuration = 0.5f;
    public int damage = 25;
    public bool playerAttack = true;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if(playerAttack)
        {
            GameObject gameObj = collision.gameObject;

            // If the projectile collided with an enemy damage it
            Enemy enemy = gameObj.GetComponent<Enemy>();
            if(enemy != null) {
                enemy.TakeDamage(damage);
            }
        }
        else
        {
            GameObject gameObj = collision.gameObject;

            // If the projectile collided with a player damage it
            Player player = gameObj.GetComponent<Player>();
            if(player != null) {
                player.TakeDamage(damage);
            }
        }

        // Otherwise delete the projectile and play the collision effect 
        GameObject collisionObj = Instantiate(collisionEffect, transform.position, transform.rotation);
        Destroy(collisionObj, collisionDuration);
        Destroy(gameObject);
    }
}
