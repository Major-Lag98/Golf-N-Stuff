using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EndMenuControl : MonoBehaviour
{

    public GameObject InputField;
    public GameObject Success;
    public GameObject Invalid;
    public GameObject InvalidTest;

    // Update is called once per frame
    void Start()
    {
        
            InputField.SetActive(true);
            Success.SetActive(false);
            Invalid.SetActive(false);
        
        
        
    }

    public void DataSubmitted()
    {
        InputField.SetActive(false);
        Success.SetActive(true);
    }
}
