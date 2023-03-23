using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private bool pause = true ;
    
    public GameStateMachine StateMachine;


    
    // Update is called once per frame
    void Update()
    {
        
        //check if player is not at the end of level
       if(StateMachine.currentState != GameStateMachine. GameState.END)
       {

                // Left Shift changes between aiming and putting
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    switch(StateMachine.currentState)
                    {
                        case(GameStateMachine.GameState.AIMIMG):
                        StateMachine.ChangeState(GameStateMachine.GameState.PUTTING);
                        break;
                        case(GameStateMachine.GameState.PUTTING):
                        StateMachine.ChangeState(GameStateMachine.GameState.AIMIMG);
                        break ;
                        
                    } 
                }
            
            //resest postions of the ball based on last postion or start
            if (Input.GetKeyDown(KeyCode.R)||Input.GetKeyDown(KeyCode.B))
            {
                if(Input.GetKeyDown(KeyCode.R))
                {
                    StateMachine.PutterObject.BallPrevPos = 
                    StateMachine.PutterObject.BallOrignalPos;
                }
               StateMachine.PutterObject.ResetGolfBall(
                StateMachine.PutterObject.BallPrevPos);
            
            }
            //pause button
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                
                //if first clicked
                if(pause)
                {
                    
                    //go into pause state
                    Time.timeScale = 0; 
                   StateMachine.ChangeState(GameStateMachine.GameState.PAUSE);
                     
                }
                else
                {
                    Time.timeScale = 1; 
                    StateMachine.ChangeState(GameStateMachine.GameState.WAITING);
                }
                
                //switch pause 
                pause = !pause; 
            }
    

       }
    }

}
