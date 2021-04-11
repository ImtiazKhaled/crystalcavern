using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : Weapon
{
    public Player playerObj;
    public Camera cam;
    public int specialDamage = 100;
    public GameState gameState;

    List<Enemy> visibleEnemies = new List<Enemy>();


    void Update()
    {
        if(!gameState.playerDead)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            // else if(Input.GetButtonDown("Fire2") & playerObj.canSpecial)
            // {
            //     Special();
            // }
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
            enemy.SpecialHit(specialDamage + gameState.attackBoost);
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
