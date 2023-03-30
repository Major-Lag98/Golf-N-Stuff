using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class PlayerData : MonoBehaviour
{

    // set up stopwatch to string
    [HideInInspector]public TimeSpan clock ;
    [HideInInspector]public string amountOfTime ; 
    [HideInInspector]public int score = 0  ; 

    void Start()
    {
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
