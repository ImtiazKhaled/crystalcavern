using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalShard : MonoBehaviour
{
    public GameState gameState;
    public AudioSource audioSource;
    public AudioClip pickupCrystal;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            audioSource.PlayOneShot(pickupCrystal, 0.10f);
            gameState.GotCrystal();
            Destroy(gameObject, 0.5f);
        }
    }
}
