using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;


public static class watch 
{
    // set stop watch and score for all levels 
    [HideInInspector]public static Stopwatch time  = new Stopwatch(); 
    public static int totalScore = 0;
    public static bool CountableRun = false;
    public static string timeString;

}
