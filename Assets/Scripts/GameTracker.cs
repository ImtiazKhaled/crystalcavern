using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GameTracker : MonoBehaviour
{
    public GameState gameState;
    public GameObject rockyMonster;
    public GameObject skullGirl;
    public Transform playerLocation;

    void Start()
    {
        gameState.Intialize();
        gameState.gameTracker = this;
        Invoke("UpdateGraph", 5f);
        InvokeRepeating("SpawnEnemiesConstant", 10f, 10f);
    }

    void UpdateGraph()
    {
        // Reload the graph after 5 seconds of loading the screen
        // This is because the map is generated, so enemies try
        // to go through obstacles
        var graphToScan = AstarPath.active.data.gridGraph;
        AstarPath.active.Scan(graphToScan);
    }

    public void SpawnEnemies(int numEnemiesToSpawn = 0, float startRange = 8f, float endRange = 13f)
    {
        int enemiesSpawned = 0;
        if(numEnemiesToSpawn == 0)
        {
            enemiesSpawned = Random.Range(1, gameState.maxEnemies - gameState.numEnemies);
            gameState.numEnemies += enemiesSpawned;
        }
        else
        {
            enemiesSpawned = numEnemiesToSpawn;
        }

        for(int i = 0; i < enemiesSpawned; i++) {
            Vector3? potentialSpawnLocation = GetValidSpawnLocation(startRange, endRange);

            if(potentialSpawnLocation != null)
            {
                Vector3 spawnLocation = potentialSpawnLocation.Value;
                int rand = Random.Range(0, 4);
                // 20% chance to spawn a skull girl
                // 80% chance to spawn a rocky monster 
                GameObject enemy = rand == 0 ? 
                    Instantiate(skullGirl, spawnLocation, Quaternion.identity) :
                    Instantiate(rockyMonster, spawnLocation, Quaternion.identity);

                Enemy enemyObj = enemy.GetComponent<Enemy>();
                if(enemyObj != null)
                {
                    enemyObj.targetPosition = playerLocation;
                }
            }
            // Even after trying 3 times, enemies will try to spawn outside the bounds
            // In that case, do not spawn that enemy, the player gets lucky
        }
    }

    public void SpawnEnemiesConstant()
    {
        SpawnEnemies(0, 8f, 13f);
    }
    Vector3? GetValidSpawnLocation(float startRange = 8f, float endRange = 13f)
    {
        Vector3 spawnLocation = Util.GetRandomPosition(playerLocation.position, startRange, endRange);

        // Not using a loop here to stop potential infinite loop
        if(!InsideScreenBounds(spawnLocation))
        {
            spawnLocation = Util.GetRandomPosition(playerLocation.position, startRange, endRange);
        }

        if(!InsideScreenBounds(spawnLocation))
        {
            spawnLocation = Util.GetRandomPosition(playerLocation.position, startRange, endRange);
        }

        if(!InsideScreenBounds(spawnLocation))
        {
            return null;
        }

        return spawnLocation;
    }

    bool InsideScreenBounds(Vector3 location)
    {
        // Check if the position is valid for the current screen bounds
        return location.x > -30 & location.x < 30 & location.y > 0 & location.y < 51;
    }
}
