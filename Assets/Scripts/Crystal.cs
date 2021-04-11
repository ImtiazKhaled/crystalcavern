using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public int crystalsNeeded = 0;
    public GameState gameState;
    public AudioSource audioSource;
    public AudioClip mergeCrystals;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        { 
            int playerCollectedCrystals = player.numCrystals;
            if(playerCollectedCrystals == crystalsNeeded)
            {
                audioSource.PlayOneShot(mergeCrystals, 0.10f);
                gameState.FinishedGame();
            }
            else
            {
                gameState.NotEnoughShards();
            }

        }
    }
}
