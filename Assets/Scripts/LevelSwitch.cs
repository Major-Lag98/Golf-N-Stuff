using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchLevel(string SceneName)
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(SceneName);

    }
}
