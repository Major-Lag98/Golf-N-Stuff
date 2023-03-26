using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{

    public Putter PutterObject;

    public CameraOrbit CameraObject;

    public GameObject OutOfBounds;

    public LevelData Data;

    public UIManager UIManage;

    public float WaitIdleTimeMax;
    private float WaitIdleTime = 0;

    public float MinSpeed;

    public bool set = true ; 

    [SerializeField] private AudioSource hitSoundEffect;

    private float limit ;
 
    public enum GameState
    {
        AIMIMG,
        PUTTING,
        WAITING,
        END,
        PAUSE
    }
    public GameState currentState;

    // Start is called before the first frame update
    void Start()
    {
        limit = OutOfBounds.transform.position.y ; 
        // start the game in aiming
        ChangeState(GameState.AIMIMG);
    } 

    // Update is called once per frame
    void Update()
    {
           if(currentState ==  GameState.WAITING)
           {
                speedAndBounds(); 
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
                set = true ; 
                break;

            case (GameState.WAITING):
                //hides ui
                ToMenu(false);
                ToWaiting(set);

 
                
                break;

            default:
                //displays ui
                ToMenu(true);
                set = false ; 
                break;
        }

    }
    //check for speed and if out of bounds 
     void speedAndBounds()
    {
        // ball is below a certin vertical height aka out of bounds, reset to previous putt
        if (PutterObject.BallRB.transform.position.y <  limit  )
        {
            PutterObject.ResetGolfBall(PutterObject.BallPrevPos);
        }
        // look to see if golfball velocity is below a certain threshhold
        if (PutterObject.BallRB.velocity.magnitude < MinSpeed)
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
    }
    public void ToAiming()
    {
        ToSetAimCameraPutter(true,true,false);
        // record the last position of the golf ball 
        PutterObject.BallPrevPos = PutterObject.BallRB.transform.position;
        
        PutterObject.ResetGolfBall(PutterObject.BallPrevPos);
    }
    public void ToPutting()
    {
        ToSetAimCameraPutter(false,false,true);

    }
    // set up control state
    public void ToSetAimCameraPutter(bool aim,bool camera, bool putter)
    {   


        // set the aiming line renderer
        CameraObject.AimLineSet(aim);

        // set Camera Movement
        CameraObject.CameraControllsSet(camera);

        // set putter if not already
        PutterObject.PutterSet(putter);


    }

    // set up waiting game state
    public void ToWaiting(bool set )
    {
        if(set)
        {
            // Play hit sound effect
            hitSoundEffect.Play();
            // add one to putt
            Data.AddPutt();
        }
        //disable all objects
        ToSetAimCameraPutter(false,false,false);
        // Enable Camera controlls after a grace period from putting
        CameraObject.SleepThenEnable();

    }

    public void ToMenu(bool check)
    {
        //disable all objects
        ToSetAimCameraPutter(false,false,false);
        if(currentState == GameState.END)
        {
            UIManage.DisplayEndUI();
            
            
        }
        else
        {
            // display the end of level menu
             UIManage.DisplayPauseUI(check);
        }
        
    }

    public void resetCounter()
    {
        WaitIdleTime = 0;
    }


}
