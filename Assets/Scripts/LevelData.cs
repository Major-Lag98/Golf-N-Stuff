using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    // mark if this level is the last of the game
    public bool FinalHole = false;

    int putts = 0;

    public void AddPutt()
    {
        putts++;
    }

    public int GetPutts()
    {
        return putts;
    }
}
