using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public static MusicLoop instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
