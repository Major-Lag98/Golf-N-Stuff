using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelect : MonoBehaviour
{
    // the different menus
    public GameObject Main;
    public GameObject LevelSelect;
    public GameObject Options;
    public GameObject HelpMenu;


    // Start is called before the first frame update
    void Start()
    {
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

}
