using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject collisionEffect;
    public float collisionDuration = 0.5f;
    public int damage = 25;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObj = collision.gameObject;

        // If the projectile collided with an enemy damage it
        Enemy enemy = gameObj.GetComponent<Enemy>();
        if(enemy != null) {
            enemy.TakeDamage(damage);
        }

        // Otherwise delete the projectile and play the collision effect 
        GameObject collisionObj = Instantiate(collisionEffect, transform.position, transform.rotation);
        Destroy(collisionObj, collisionDuration);
        Destroy(gameObject);
    }
}
