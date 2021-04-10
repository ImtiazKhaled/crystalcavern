using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameState", menuName="State/GameState")]
public class GameState : ScriptableObject
{
    public float gameTime = 0;
    public List<Transform> crystalLocations = new List<Transform>();

    public void Intialize()
    {
        gameTime = 0;
        crystalLocations = new List<Transform>();
    }
}
