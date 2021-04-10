using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GameTracker : MonoBehaviour
{
    public GameState gameState;
    void Start()
    {
        gameState.Intialize();
        Invoke("UpdateGraph", 5f);    
    }

    void UpdateGraph()
    {
        // Reload the graph after 5 seconds of loading the screen
        // This is because the map is generated, so enemies try
        // to go through obstacles
        var graphToScan = AstarPath.active.data.gridGraph;
        AstarPath.active.Scan(graphToScan);
    }
}
