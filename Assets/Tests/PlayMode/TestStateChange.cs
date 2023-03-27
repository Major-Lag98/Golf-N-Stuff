using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class GameStateMachineTests
{
    [UnityTest]
    public IEnumerator ChangesStateToAimimg()
    {
        // Arrange
        var gameObject = new GameObject();
        var gameStateMachine = gameObject.AddComponent<GameStateMachine>();

        // Act
        gameStateMachine.ChangeState(GameStateMachine.GameState.AIMIMG);

        // Wait for a frame to allow state changes to occur
        yield return null;

        // Assert
        Assert.AreEqual(GameStateMachine.GameState.AIMIMG, gameStateMachine.currentState);

        // Clean up
        GameObject.Destroy(gameObject);
    }
}