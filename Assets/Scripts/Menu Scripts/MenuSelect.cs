using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class MenuSelect : MonoBehaviour
{

    // Array of all menues
    public GameObject[] Menues;

    // canvas transitioner for start game button
    public GameObject TransitionCanvas;
    
    // the different menus
    public GameObject Main;
    public GameObject LevelSelect;
    public GameObject Options;
    public GameObject HelpMenu;


    // Start is called before the first frame update
    void Start()
    {
        watch.time = new Stopwatch();
        watch.totalScore = 0 ; 
        SetMenuMain();

    }

    // set menu to level select
    public void SetMenuLevelSelect()
    {
        // disable both Options, Help, and Main
        Main.SetActive(false);
        Options.SetActive(false);
        HelpMenu.SetActive(false);
        // enable Select Level
        LevelSelect.SetActive(true);
    }

    // set menu to options
    public void SetMenuOptions()
    {
        // disable both Main, help, and select
        LevelSelect.SetActive(false);
        Main.SetActive(false);
        HelpMenu.SetActive(false);
        // enable Options
        Options.SetActive(true);
    }

    // set menu to main
    public void SetMenuMain()
    {
        // disable both Options and select
        LevelSelect.SetActive(false);
        Options.SetActive(false);
        HelpMenu.SetActive(false);
        // enable Main
        Main.SetActive(true);
    }

    // set menu to help menu
    public void SetMenuHelpMenu()
    {
      // disable main, options, and select
      LevelSelect.SetActive(false);
      Main.SetActive(false);
      Options.SetActive(false);
      // enable help menu
      HelpMenu.SetActive(true);
   }

    // disable the 3 menu objects specified and enable the one you want
    void SetMenuHelper(Menu goToMenu)
    {
        // first disable all menues
        Main.SetActive(false);
        //LevelSelect.SetActive(false);
        Credits.SetActive(false);
        Options.SetActive(false);
        
        // Enable the one needed
        switch (goToMenu)
        {
            case Menu.Main:
                Main.SetActive(true);
                break;
            /*case Menu.LevelSelect:
                LevelSelect.SetActive(true);
                break;*/
            case Menu.Credits:
                Credits.SetActive(true);
                break;
            case Menu.Options:
                Options.SetActive(true);
                break;
        }

        // set current menu
        currentMenu = goToMenu;
    }

    // plays the correct out animation based on the menu passed - only 4 menus
    void playOutAnimations()
    {
        // find and set the animations to be played
        Animator[] animationsToBePlayed;
        switch(currentMenu)
        {
            case Menu.Main:
                animationsToBePlayed = MainMenuOutAnimations;
                break;
            case Menu.Options:
                animationsToBePlayed = OptionsOutAnimations;
                break;
            case Menu.Credits:
                animationsToBePlayed = CreditsOutAnimations;
                break;
            default:
                animationsToBePlayed = new Animator[0];
                break;
        }

        // play out the assigned animations
        foreach(Animator animation in animationsToBePlayed)
        {
            animation.SetTrigger(outAnimTrigger);
        }

    }

    // plays out animation, waits for it to finish, then changes menu
    IEnumerator ChangeMenuAndWaitForAnim(Menu goToMenu)
    {
        // loop through each animation and activate its "out" trigger
        playOutAnimations();
        
        // wait for animation to finish
        yield return new WaitForSeconds(0.5f);

        // special case if game start
        if (goToMenu == Menu.StartGame)
        {
            // instantiate a level switch to change to level one
            LevelSwitch LS = gameObject.AddComponent<LevelSwitch>();
            LS.TransitionCanvas = TransitionCanvas;
            LS.SwitchNextLevel();
            yield return null;
        }
        // else change menu
        SetMenuHelper(goToMenu);
    }

}
