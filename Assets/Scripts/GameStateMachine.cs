using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public Putter PutterObject;
    public CameraOrbit CameraObject;

    public Rigidbody GolfBall;

    public float WaitIdleTimeMax;
    float WaitIdleTime = 0;

    public float MinSpeed;

    public enum GameState
    {
        AIMIMG,
        PUTTING,
        WAITING
    }
    public GameState currentState;

    // Start is called before the first frame update
    void Start()
    {
        // start the game in aiming
        ChangeState(GameState.AIMIMG);
    }

    // Update is called once per frame
    void Update()
    {
        // do things continuously depending on which state were in
        switch (currentState)
        {
            case (GameState.AIMIMG):
                break;

            case (GameState.PUTTING):
                break;

            case (GameState.WAITING):
                // look to see if golfball velocity is below a certain threshhold
                if (GolfBall.velocity.magnitude < MinSpeed)
                {
                    // start counting
                    WaitIdleTime += Time.deltaTime;

                    // if we are not moving for x amount of time
                    if (WaitIdleTime > WaitIdleTimeMax)
                    {
                        // change to aiming
                        ChangeState(GameState.AIMIMG);
                        resetCounter();
                    }
                }
                else
                {
                    resetCounter();
                }
                break;
        }
    }


    // handler for changing state
    public void ChangeState(GameState newState)
    {
        // set the current state
        currentState = newState;

        // call state initialization
        switch (currentState)
        {
            case (GameState.AIMIMG):
                ToAiming();
                break;

            case (GameState.PUTTING):
                ToPutting();
                break;

            case (GameState.WAITING):
                ToWaiting();
                break;

        }

    }

    // set up aiming game state
    public void ToAiming()
    {

        // Enable the aiming line renderer
        CameraObject.EnableAimLine();

        // Enable Camera Movement
        CameraObject.EnableCameraControlls();

        // Dsiable putter if not already
        PutterObject.DisablePutter();

        GolfBall.velocity = Vector3.zero;
        GolfBall.angularVelocity = Vector3.zero;

    }

    // set up putting game state
    public void ToPutting()
    {
        // disable the aim line renderer
        CameraObject.DisableAimLine();

        // disable camera controlls
        CameraObject.DisableCameraControlls();

        // enable the putter object
        PutterObject.EnablePutter();

    }

    // set up waiting game state
    public void ToWaiting()
    {
        // Dsiable putter
        PutterObject.DisablePutter();

        // Enable Camera controlls after a grace period from putting
        CameraObject.SleepThenEnable();

        // turn off indicator
        CameraObject.DisableAimLine();

    }

    void resetCounter()
    {
        WaitIdleTime = 0;
    }

}
