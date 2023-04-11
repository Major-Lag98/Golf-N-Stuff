using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class MenuSelect : MonoBehaviour
{

    // the different menus
    public GameObject Main;
    public GameObject LevelSelect;
    public GameObject Options;
    public GameObject HelpMenu;

    string outAnimTrigger = "out";
    public Animator[] MainMenuOutAnimations;


    // Start is called before the first frame update
    void Start()
    {
        watch.time = new Stopwatch();
        watch.totalScore = 0;

        // start off the scene looking at the main menu
        SetMenuHelper(LevelSelect, Options, HelpMenu, Main);

    }

    // set menu to level select
    public void SetMenuLevelSelect()
    {
        StartCoroutine(ChangeMenuAndWaitForAnim(Main, Options, HelpMenu, LevelSelect));
    }

    // set menu to options
    public void SetMenuOptions()
    {
        StartCoroutine(ChangeMenuAndWaitForAnim(LevelSelect, Main, HelpMenu, Options));
    }

    // set menu to main
    public void SetMenuMain()
    {
        StartCoroutine(ChangeMenuAndWaitForAnim(LevelSelect, Options, HelpMenu, Main));
    }

    // set menu to help menu
    public void SetMenuHelpMenu()
    {
        StartCoroutine(ChangeMenuAndWaitForAnim(LevelSelect, Main, Options, HelpMenu));
    }

    // disable the 3 menu objects specified and enable the one you want
    void SetMenuHelper(GameObject firstDisable, GameObject secondDisable, GameObject thirdDisable, GameObject enable)
    {
        // disable the first 3
        firstDisable.SetActive(false);
        secondDisable.SetActive(false);
        thirdDisable.SetActive(false);

        // enable the last
        enable.SetActive(true);
    }

    IEnumerator ChangeMenuAndWaitForAnim(GameObject firstDisable, GameObject secondDisable, GameObject thirdDisable, GameObject enable)
    {
        // loop through each animation and activate its "out" trigger
        foreach (Animator animation in MainMenuOutAnimations)
        {
            UnityEngine.Debug.Log("Setting out trigger");
            animation.SetTrigger(outAnimTrigger);
        }

        yield return new WaitForSeconds(0.5f);
        SetMenuHelper(firstDisable, secondDisable, thirdDisable, enable);
    }
}
