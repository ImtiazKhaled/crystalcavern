using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int enemyDamage = 25;
    public Transform target;
    public float speed = 200f;
    public int speicalGained = 25;
    public float nextWaypointDistance = 3f;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public GameState gameState;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    Transform enemyPosition;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        enemyPosition = GetComponent<Transform>();

        InvokeRepeating("UpdatePath", 0f, 1f);
    }
    void Update()
    {
        if(path == null)
        {
            return;
        }

        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            EnemyHit();
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if ( distance < nextWaypointDistance)
        {
            currentWayPoint++;
        }

        if (force.x >= 0.01f)
        {
            enemyPosition.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            enemyPosition.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    # region Enemy Pathfinding 
    void UpdatePath()
    {
        if(seeker.IsDone()){
            seeker.StartPath(rb.position, target.position, OnPathFound);
        }
    }
    void OnPathFound(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }
    #endregion

    # region Enemy Attack 
    void EnemyHit()
    {
        // If the enemy is in the attack animation, don't attack
        // This makes the enemy attack physically if the player is within range of the enemy
        if(reachedEndOfPath) {
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
            foreach(Collider2D player in hitPlayer)
            {
                Player playerObj = player.GetComponent<Player>();

                if(playerObj != null) 
                {
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

    #endregion

    #region Enemy Health
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public void SpecialHit(int damage)
    {
        health -= damage;
        // Play exploding animation

        // Delete the object if the health is zero
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        // otherwise let them return back to normal
    }

    void Die()
    {
        gameState.EnemyDied(speicalGained);
        // Play die animation here
        Destroy(gameObject);
    }
    #endregion
}
