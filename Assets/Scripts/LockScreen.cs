using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Keep mouse locked to middle of screen when player clicks on screen */
public class LockScreen : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // if we click on the game screen and the cursor is not locked
        if (Input.GetMouseButtonDown(0) && Cursor.lockState != CursorLockMode.Locked)
        {
            // lock it
            Cursor.lockState = CursorLockMode.Locked;

        }

        // if we press escape unlock the screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
