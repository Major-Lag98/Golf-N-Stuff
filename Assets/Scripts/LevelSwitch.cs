using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    // canvas prefab for transition animation
    public GameObject TransitionCanvas;


    // load specific level
    public void SwitchLevelInt(int SceneIndex)
    {
        StartCoroutine(WaitForAnimation(SceneIndex));
    }

    // load next level
    public void SwitchNextLevel()
    {
        // get current index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // begin animation, pass next scene to load
        StartCoroutine(WaitForAnimation(currentSceneIndex + 1));
    }

    IEnumerator WaitForAnimation(int sceneToLoad)
    {
        // spawn the transition gameobject, animation played upon gameobject start()
        Instantiate(TransitionCanvas);

        // make sure time is playing for animation
        Time.timeScale = 1;

        // wait for middle of transition animation
        yield return new WaitForSeconds(1.5f);

        // load scene
        loadSceneIndex(sceneToLoad);
    }

    // load given scene
    private void loadSceneIndex(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
