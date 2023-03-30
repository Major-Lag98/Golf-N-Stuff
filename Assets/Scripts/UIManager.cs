using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public LevelData Data;
    public TMP_Text NumberOfPuttsDisplay;
    public TMP_Text timerDisplay;
    public TMP_Text ParDisplay;
    public TMP_Text totalTimeDisplay;
    public TMP_Text FinalTermDisplay;
    public TMP_Text PauseTermDisplay;

    public GameObject PlayingUI;
    public  GameObject EndLevelUI;
    public  GameObject PauseLevelUI;
    public Buttons check; 

    void Start()
    {
        
        timerDisplay.SetText(Data.Player.amountOfTime);
        displayPlayingUI(true);

    }
    void Update()
    {
        timerDisplay.SetText(Data.Player.amountOfTime); 

    }
    // number of putts should update each stroke
    public void UpdatePuttsText(int strokes)
    {
        NumberOfPuttsDisplay.SetText($"Putts: {strokes}");
    }

    // par text should be set as soon as level starts
    public void SetParText(int par)
    {
        ParDisplay.SetText($"Par: {par}");
    }


    // This function is to be used to display the proper term when a hole is made
    public void SetFinalTermText(int strokes, int par)
    {
        string term = GetTerm(strokes, par);

        FinalTermDisplay.SetText(term);
    }



    // Get the correct term in the dictionary. If the key doesnt exist just return the ammount of putts
    public string GetTerm(int strokes, int par)
    {
        string text;

        int key = strokes - par;

        // if the key exists
        if (Terms.Text.ContainsKey(key))
        {
            // set the text to either: Hole in one or the correct dictionary term
            text = strokes == 1 ? "Hole in one!!" : Terms.Text[key];
        }
        else // set the text to the number of strokes
        {
            text = $"{strokes} strokes";
        }

        return text;
    }

    public void DisplayEndUI()
    {
        SetFinalTermText(Data.GetPutts(), Data.Par);
        Data.displayResults(); 
        EndLevelUI.SetActive(true);
    }
    public void DisplayPauseUI(bool set )
    { 
        PauseLevelUI.SetActive(set);

    }
    public void displayPlayingUI(bool set)
    {
        PlayingUI.SetActive(set); 

    }

}
