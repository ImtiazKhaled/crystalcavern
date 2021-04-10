using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalLevel : MonoBehaviour
{
    public Transform crystalShardLocation;
    public GameState gameState;

    void Start()
    {
        gameState.crystalLocations.Add(crystalShardLocation);
    }
}
