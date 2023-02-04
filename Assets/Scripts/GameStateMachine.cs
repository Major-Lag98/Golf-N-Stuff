using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public Putter PutterObject;
    public CameraOrbit CameraObject;

    public Rigidbody GolfBall;

    public float yPosition;

    public float WaitIdleTimeMax;
    float WaitIdleTime = 0;

    public float MinSpeed;

    public int MinYValue;

    public float WinYValue;

    [SerializeField] private AudioSource hitSoundEffect;

    private Vector3 lastPos;
    public enum GameState
    {
        AIMIMG,
        PUTTING,
        WAITING,
        END
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
                // Check if ball is at the bottom of the hole
                if (GolfBall.transform.position.y == WinYValue)
                {
                    Debug.Log("IN THE HOLE");
                }
                break;

            case (GameState.PUTTING):
                break;

            case (GameState.WAITING):
                // ball is below a certin vertical height aka out of bounds, reset to previous putt
                if (GolfBall.transform.position.y <  MinYValue)
                {
                    ResetGolfBallVelocity();
                    GolfBall.transform.position = lastPos;
                }
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
        // record the last position of the golf ball 
        lastPos = GolfBall.transform.position;

        // Enable the aiming line renderer
        CameraObject.EnableAimLine();

        // Enable Camera Movement
        CameraObject.EnableCameraControlls();

        // Dsiable putter if not already
        PutterObject.DisablePutter();

        
        ResetGolfBallVelocity();

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
        // Play hit sound effect
        hitSoundEffect.Play();
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


    void ResetGolfBallVelocity()
    {
        // set velocity to 0
        GolfBall.velocity = Vector3.zero;

        // set angular velocity to 0
        GolfBall.angularVelocity = Vector3.zero;

    }
}
