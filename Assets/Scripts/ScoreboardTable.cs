using System;
using System.Collections;
/*using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;*/
using UnityEngine.Networking;
using TMPro;
using UnityEngine;
/*using UnityEngine.UI;
using JetBrains.Annotations;
using MacFsWatcher;*/

public class ScoreboardTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private string scoreURL = "http://localhost:8000/displayScore.php";
    private string timeURL = "http://localhost:8000/displayTime.php";
    private string URL = "http://localhost:8000/displayScore.php";
    private string nameResultText;
    private string scoreResultText;
    private string timeResultText;
    public string[] Data;



    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get(URL);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error retrieving website data: " + request.error);
        }
        else
        {
            string websiteText = request.downloadHandler.text;
            websiteText = websiteText.Replace("\n", "");
            // Split the website text using underscores
            Data = websiteText.Split('_');
            makeTable();
        }
        
    }


private void makeTable()
    {
        int scoreSize = 17;

        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("DataTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 20f;

        Debug.Log(Data.Length);

        if (Data.Length / 3 < scoreSize)
        {
            scoreSize = Data.Length / 3;
        }
        Debug.Log(scoreSize);

        for (int i = 0; i < scoreSize; i++)
        {
            Transform entryData = Instantiate(entryTemplate, entryContainer);
            entryData.tag = "Clone";
            RectTransform entryRectTransform = entryData.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0f, -templateHeight * i);
            entryData.gameObject.SetActive(true);


            TMP_Text username = entryData.Find("usernameText").GetComponent<TMP_Text>();
            username.SetText(Data[i * 3]);

            TMP_Text score = entryData.Find("scoreText").GetComponent<TMP_Text>();
            score.SetText(Data[i * 3 + 1]);

            TMP_Text time = entryData.Find("timeText").GetComponent<TMP_Text>();
            time.SetText(Data[i * 3 + 2]);

            TMP_Text key = entryData.Find("keyText").GetComponent<TMP_Text>();
            key.SetText((i + 1).ToString());
        }
    }

    public void DeleteObjectsWithName(string name)
    {
        // Find all game objects with the given name
        GameObject[] objects = GameObject.FindGameObjectsWithTag(name);

        // Loop through all the game objects with the given name and delete them
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
    public void UpdateScoreboard(int typeBoard)
    {
        DeleteObjectsWithName("Clone");

        if (typeBoard == 0)
        {
            URL = scoreURL;
        }
        else if (typeBoard == 1) 
        {
            URL = timeURL;
        }

        StartCoroutine(Start());
    }

}
