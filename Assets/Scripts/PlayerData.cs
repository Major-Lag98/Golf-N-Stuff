using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    // determin if the player started from the beginning "a countable run" or
    // from the level select
    public bool CountableRun = false;
    // set up stopwatch to string
    [HideInInspector]public TimeSpan clock ;
    public string amountOfTime ; 
 
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        //set stop watch at the first frame 
        watch.time.Start();
    }

    void Update()
    {
        //display time span as as string 
        clock = watch.time.Elapsed ; 
        amountOfTime =watch.time.Elapsed.ToString (@"mm\:ss\:fff");      
    }
    

}
