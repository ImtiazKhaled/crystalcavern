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
    public bool playerDead;

    public void Intialize()
    {
        playerDead = false;
        gameTime = 0;
        crystalShardLocations = new List<Transform>();
        crystalLocation = null;
    }

    public void EnemyDied(int speicalGained)
    {
        player.GainSpeical(speicalGained);
    }
}
