using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.Lumin;

public class LevelData : MonoBehaviour
{
    public UIManager UImanage;

    public PlayerData Player;


    // mark if this level is the last of the game
    public bool FinalHole = false;

    public int Putts = 0;

    public int Par;

    private void Start()
    {
        Player = GameObject.FindObjectOfType<PlayerData>();
        // Zero Putt Display
        UImanage.UpdatePuttsText(Putts);
        // update the Par display on the screen at the start of the level
        UImanage.SetParText(Par);

    }

    public void AddPutt()
    {
        Putts++;

        //Debug.Log(putts);

        // send an update to the hud
        UImanage.UpdatePuttsText(Putts);
        // set world score to new updated putts
         watch.totalScore++ ;
        


    }

    public int GetPutts()
    {
        return Putts;
    }
    public void displayResults()
    {
            ///disply the end time and make sure that playing ui is not shown
            UImanage.totalTimeDisplay.SetText(this.Player.amountOfTime);
            UImanage.displayPlayingUI(false); 
        

    } 
}
