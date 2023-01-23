using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    bool locked = false;

    public GameStateMachine StateMachine;

    public Transform Ball;
    Vector3 BallOriginalPos;
    Rigidbody ballRB;

    void Start()
    {
        
        BallOriginalPos = Ball.position;
        ballRB = Ball.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // lock cursor when ` is pressed
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            locked = !locked;

            if (locked) Cursor.lockState = CursorLockMode.Locked;
            else Cursor.lockState = CursorLockMode.None;
        }

        // R resets position
        if (Input.GetKeyDown(KeyCode.R))
        {
            Ball.position = BallOriginalPos;
            ballRB.velocity = Vector3.zero;
            ballRB.angularVelocity = Vector3.zero;
        }

        // Left Shift changes between aiming and putting
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (StateMachine.currentState == GameStateMachine.GameState.AIMIMG)
            {
                StateMachine.ChangeState(GameStateMachine.GameState.PUTTING);
            }
            else if (StateMachine.currentState == GameStateMachine.GameState.PUTTING)
            {
                StateMachine.ChangeState(GameStateMachine.GameState.AIMIMG);
            }
        }


    }

}
