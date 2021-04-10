using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crystal : MonoBehaviour
{
    public int crystalsNeeded = 3;
    int numCrystals = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            bool tookCrystal = player.TakeACrystal();

            if(tookCrystal)
            {
                numCrystals++;

                if(numCrystals == crystalsNeeded)
                {
                    // Play some animation and dialog here
                    SceneManager.LoadScene("End");
                }
            }

        }
    }
}
