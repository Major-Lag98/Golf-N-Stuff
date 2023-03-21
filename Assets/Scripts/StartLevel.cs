using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    
    public void StartGolf(int index)
    {
        SceneManager.LoadScene(index);
    }

}
