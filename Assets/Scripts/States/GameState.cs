using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameState", menuName="State/GameState")]
public class GameState : ScriptableObject
{
    public float gameTime = 0;
    public List<Transform> crystalShardLocations = new List<Transform>();
    public Transform crystalLocation;
    public Player player;
    public GameTracker gameTracker;
    public bool playerDead;
    public int numEnemies;
    public int maxEnemies;
    public int cyrstalMonsterMobNumber;
    public int attackBoost;
    public int speedBoost;
    public int defenseBoost;

    public void Intialize()
    {
        playerDead = false;
        gameTime = 0;
        crystalShardLocations = new List<Transform>();
        crystalLocation = null;
        numEnemies = 0;
        maxEnemies = 5;
        cyrstalMonsterMobNumber = 7;
        attackBoost = 0;
        speedBoost = 0;
        defenseBoost = 0;
    }

    public void EnemyDied(int speicalGained)
    {
        player.GainSpeical(speicalGained);
    }

    public void GotCrystal()
    {
        int boostChoice = Random.Range(0, 2);
        Debug.Log("Choice was " + boostChoice);
        switch(boostChoice)
        {
            default:
            case 0:
                attackBoost += 20;
                break;
            case 1:
                speedBoost += 3;
                break;
            case 2:
                defenseBoost += 15;
                break;
        }

        maxEnemies += 5;
        int numEnemiesToSpawn = (cyrstalMonsterMobNumber * 2) - ((crystalShardLocations.Count + 1) * 2);
        gameTracker.SpawnEnemies(numEnemiesToSpawn, 5f, 9f);
    }
}
