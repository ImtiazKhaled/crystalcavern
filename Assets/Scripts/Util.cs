using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    static public Vector3 GetRandomPosition(Vector3 startPosition, float startRange = 8f, float endRange = 13f)
    {
        return startPosition + GetRandomDir() * GetRandomDist();
    }

    static public float GetRandomDist(float startRange = 8f, float endRange = 13f)
    {
        return Random.Range(startRange, endRange);
    }
    
    static public Vector3 GetRandomDir()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
