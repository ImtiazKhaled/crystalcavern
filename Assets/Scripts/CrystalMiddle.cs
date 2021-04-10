using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMiddle : MonoBehaviour
{
    public Transform crystalLocation;
    public GameState gameState;

    void Start()
    {
        gameState.crystalLocation = crystalLocation;
    }
}
