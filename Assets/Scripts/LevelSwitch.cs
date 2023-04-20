using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    
    public string  SceneName; 
    public void SwitchLevelStr(string  SceneName)
    {
        //Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(SceneName,LoadSceneMode.Single); 

    }

    public void SwitchLevelInt(int SceneIndex)
    {
        //Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(SceneIndex);
    }

    public void SwitchNextLevel()
    {
        // load next scene by build index      
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex + 1 == 1)
        {
            watch.CountableRun = true;
        }

        SceneManager.LoadScene( currentSceneIndex + 1);
    }
}
