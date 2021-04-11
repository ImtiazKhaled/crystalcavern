using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalShard : MonoBehaviour
{
    public GameState gameState;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            player.AcquireCrystal();
            gameState.GotCrystal();
            Destroy(gameObject);
        }
    }
}
