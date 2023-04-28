using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

public class AddRunToDatabase : MonoBehaviour
{
    public string defaultURL = "http://142.11.252.18:8080/addPlayerData.php";

    public string input;
    public string completeURL;

    void createCompleteURL() // also int time when the time comes
    {
        completeURL = "http://142.11.252.18:8080/addPlayerData.php" + "?username=" + input + "&score=" + watch.totalScore.ToString() +
                                                          "&time=" + watch.timeString;

    }


    public void SendInputAndData(String name)
    {
        input = name;
        Debug.Log(input);

        createCompleteURL();

        Debug.Log(completeURL);

        UnityWebRequest.Get(completeURL).SendWebRequest();
    }

    
}
