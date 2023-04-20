using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputLengthLimiter : MonoBehaviour
{

    private InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
        inputField.characterLimit = 3;
    }

   
}
