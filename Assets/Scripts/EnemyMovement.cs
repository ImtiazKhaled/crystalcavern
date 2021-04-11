using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyMovement : MonoBehaviour
{
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public Animator animator;
    Vector3 currentTarget;
    Path path;
    int currentWayPoint = 0;

    Seeker seeker;
    Rigidbody2D rb;
    Transform enemyPosition;
    bool stopMove = false;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        enemyPosition = GetComponent<Transform>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }
    void FixedUpdate()
    {
        if(!stopMove)
        {
            animator.SetFloat("MoveSpeed", rb.velocity.magnitude);
            if(path == null)
            {

                return;
            }

            if(currentWayPoint >= path.vectorPath.Count)
            {
                return;
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
    }

    void UpdatePath()
    {
        if(seeker.IsDone()){
            seeker.StartPath(rb.position, currentTarget, OnPathFound);
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

    public void SetTarget(Vector3 target)
    {

        currentTarget = target;
    }
    public void StopMove()
    {
        stopMove = true;
    }

    public void ContinueMove()
    {
        stopMove = false;
    }
}
