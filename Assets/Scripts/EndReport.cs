using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Diagnostics;

public class EndReport : MonoBehaviour
{
    public TMP_Text PlayerScoreText;
    public TMP_Text PlayerTime;



    // Start is called before the first frame update
    void Start()
    {
        PlayerScoreText.SetText("Your Score: " + watch.totalScore.ToString());

        TimeSpan ts = watch.time.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        watch.timeString = elapsedTime;
        PlayerTime.SetText("Your Time: " + elapsedTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
