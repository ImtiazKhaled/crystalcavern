using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 20f;
    public Rigidbody2D weaponRb;
    public Transform weaponPosition;
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePosition;
    bool facingRight = true;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Vector2 pointDir = mousePosition - weaponRb.position;

        if(pointDir.x < -0.01 & facingRight) 
        {
            // Play moving left animation
            facingRight = false;
        }

        else if(pointDir.x > 0.01 & !facingRight) 
        {
            // Play moving right animation
            facingRight = true;
        }

        // if (movement.x == 0 & movement.y == 0)
        // {
        //     animator.SetFloat("MoveSpeed", 0f);
        // }
        // else
        // {
        //     animator.SetFloat("MoveSpeed", moveSpeed);
        // }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        weaponRb.MovePosition(new Vector2(weaponPosition.position.x, weaponPosition.position.y) + movement * moveSpeed * Time.fixedDeltaTime);

        float angle = Mathf.Atan2(pointDir.y, pointDir.x) * Mathf.Rad2Deg;
        weaponRb.rotation = angle;
    }
}
