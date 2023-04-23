using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{

    public GameObject TransitionCanvas;

    
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
        // spawn the transition gameobject
        Instantiate(TransitionCanvas);
        StartCoroutine(WaitForAnimation());
    }

    private void loadNextSceneIndex()
    {
        // load next scene by build index      
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    IEnumerator WaitForAnimation()
    {
        // wait for middle of transition animation
        yield return new WaitForSeconds(1.5f);
        // load next scene
        loadNextSceneIndex();
    }

}
