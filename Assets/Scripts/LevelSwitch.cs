using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    public string SceneName;
    public Animator fadeAnimator; // reference to the fadeout animator component

    public void SwitchLevelStr(string SceneName)
    {
        Debug.Log("You have clicked the button!");
        StartCoroutine(SwitchLevelWithFade(SceneName));
    }

    public void SwitchLevelInt(int SceneIndex)
    {
        Debug.Log("You have clicked the button!");
        StartCoroutine(SwitchLevelWithFade(SceneIndex));
    }

    IEnumerator SwitchLevelWithFade(string SceneName)
    {
        fadeAnimator.SetTrigger("FadeOut"); // play the fadeout animation
        yield return new WaitForSeconds(1f); // wait for the animation to finish
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single); // load the new scene
    }

    IEnumerator SwitchLevelWithFade(int SceneIndex)
    {
        fadeAnimator.SetTrigger("FadeOut"); // play the fadeout animation
        yield return new WaitForSeconds(1f); // wait for the animation to finish
        SceneManager.LoadScene(SceneIndex); // load the new scene
    }
}
