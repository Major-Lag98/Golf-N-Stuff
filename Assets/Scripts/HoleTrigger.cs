using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{

    public GameStateMachine StateMachine;

    // This function is called once when a trigger on this GameObject is entered
    private void OnTriggerEnter(Collider other)
    {
        // the the object is a player
        if (other.tag == "Player")
        {
            // change the game state to END
            StateMachine.ChangeState(GameStateMachine.GameState.END);
        }
    }
}
