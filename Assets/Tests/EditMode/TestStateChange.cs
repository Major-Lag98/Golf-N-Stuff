using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class TestStateChange
{
    private GameStateMachine gameStateMachine;

    [SetUp]
    public void SetUp()
    {
        GameObject gameStateMachineGameObject = new GameObject();
        gameStateMachine = gameStateMachineGameObject.AddComponent<GameStateMachine>();
    }

    [Test]
    public void ChangeState_SetsCorrectState()
    {
        // Arrange
        GameStateMachine.GameState expectedState = GameStateMachine.GameState.AIMIMG;

        // Act
        gameStateMachine.ChangeState(GameStateMachine.GameState.AIMIMG);

        // Assert
        Assert.AreEqual(expectedState, gameStateMachine.currentState);
    }
}
