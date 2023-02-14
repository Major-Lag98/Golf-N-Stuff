using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.Lumin;

public class LevelData : MonoBehaviour
{
    public UIManager UImanage;

    public PlayerData Player;

    // mark if this level is the last of the game
    public bool FinalHole = false;

    int putts = 0;

    public int Par;

    private void Start()
    {
        Player = GameObject.FindObjectOfType<PlayerData>();
        // Zero Putt Display
        UImanage.UpdatePuttsText(putts);
        // update the Par display on the screen at the start of the level
        UImanage.SetParText(Par);

    }

    public void AddPutt()
    {
        putts++;

        Debug.Log(putts);

        // send an update to the hud
        UImanage.UpdatePuttsText(putts);
        // set world score to new updated putts
        Player.Score += 1;



    }

    public int GetPutts()
    {
        return putts;
    }
}
