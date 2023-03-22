using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    
    public string  SceneName; 
    public void SwitchLevelStr(string  SceneName)
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(SceneName,LoadSceneMode.Single);
        

    }

    public void SwitchLevelInt(int SceneIndex)
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(SceneIndex);

    }
}
