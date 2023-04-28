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
        if (watch.CountableRun)
        {
            InputField.SetActive(true);
            Success.SetActive(false);
            Invalid.SetActive(false);
        }
        else
        {
            InputField.SetActive(false);
            Success.SetActive(false);
            Invalid.SetActive(true);
        }
        
    }

    public void DataSubmitted()
    {
        InputField.SetActive(false);
        Success.SetActive(true);
    }
}
