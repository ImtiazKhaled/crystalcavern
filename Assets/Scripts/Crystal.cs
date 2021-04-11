using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public int crystalsNeeded = 0;
    public GameState gameState;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        { 
            int playerCollectedCrystals = player.numCrystals;
            if(playerCollectedCrystals == crystalsNeeded)
            {
                gameState.FinishedGame();
            }
            else
            {
                gameState.NotEnoughShards();
            }

        }
    }
}
