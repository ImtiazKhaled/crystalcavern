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
        gameTime = 0;
        crystalShardLocations = new List<Transform>();
        crystalLocation = null;
        numEnemies = 0;
        maxEnemies = 5;
        cyrstalMonsterMobNumber = 6;
        attackBoost = 0;
        speedBoost = 0;
        defenseBoost = 0;
        playerDead = false;
    }

    public void EnemyDied(int speicalGained)
    {
        player.GainSpeical(speicalGained);
    }

    public void GotCrystal()
    {
        player.AcquireCrystal();
        maxEnemies += 2;
        int numEnemiesToSpawn = cyrstalMonsterMobNumber - crystalShardLocations.Count;
        gameTracker.GotCrystal(numEnemiesToSpawn);

        if(crystalShardLocations.Count == 1) 
        {
            gameTracker.LastCrystalShard();
        }
    }

    public void AttackUpgrade()
    {
        attackBoost += 22;
        gameTracker.CloseMenu();
    }

    public void DefenseUpgrade()
    {
        defenseBoost += 16;
        gameTracker.CloseMenu();
    }

    public void SpeedUpgrade()
    {
        speedBoost += 1;
        gameTracker.CloseMenu();
    }

    public void NotEnoughShards()
    {
        gameTracker.NotEnoughShards();
    }

    public void FinishedGame()
    {
        gameTracker.MergedShards();
    }
}
