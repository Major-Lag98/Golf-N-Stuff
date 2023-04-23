using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Keep mouse locked to middle of screen when player clicks on screen */
public class LockScreen : MonoBehaviour
{
    public GameStateMachine State;

    // Update is called once per frame
    void Update()
    {
        // if we press escape unlock the screen, or the level is over
        if (State.currentState == GameStateMachine.GameState.END ||
        State.currentState == GameStateMachine.GameState.PAUSE||
        Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        // if we click on the game screen and the cursor is not locked
        else if (Input.GetMouseButtonDown(0) && Cursor.lockState != CursorLockMode.Locked)
        {
            // lock it
            Cursor.lockState = CursorLockMode.Locked;

        }

    }
}
