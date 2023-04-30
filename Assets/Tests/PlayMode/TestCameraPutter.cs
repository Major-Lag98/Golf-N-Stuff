using NUnit.Framework;
using UnityEngine;

public class TestCameraPutter
{
    [Test]
    public void ToSetAimCameraPutter_EnablesAimCameraPutter()
    {
        // Arrange
        var gameStateMachine = new GameObject().AddComponent<GameStateMachine>();
        var cameraOrbit = new GameObject().AddComponent<CameraOrbit>();
        var putter = new GameObject().AddComponent<Putter>();
        gameStateMachine.CameraObject = cameraOrbit;
        gameStateMachine.PutterObject = putter;

        // Act
        gameStateMachine.ToSetAimCameraPutter(true, true, true);

        // Assert
        Assert.IsTrue(cameraOrbit.AimLineRenderer.enabled);
        Assert.IsTrue(cameraOrbit.CameraControlsEnabled);
        Assert.IsTrue(putter.PutterControlsEnabled);
    }

    [Test]
    public void ToSetAimCameraPutter_DisablesAimCameraPutter()
    {
        // Arrange
        var gameStateMachine = new GameObject().AddComponent<GameStateMachine>();
        var cameraOrbit = new GameObject().AddComponent<CameraOrbit>();
        var putter = new GameObject().AddComponent<Putter>();
        cameraOrbit.AimLineRenderer.enabled = true;
        cameraOrbit.CameraControlsEnabled = true;
        putter.PutterControlsEnabled = true;
        gameStateMachine.CameraObject = cameraOrbit;
        gameStateMachine.PutterObject = putter;

        // Act
        gameStateMachine.ToSetAimCameraPutter(false, false, false);

        // Assert
        Assert.IsFalse(cameraOrbit.AimLineRenderer.enabled);
        Assert.IsFalse(cameraOrbit.CameraControlsEnabled);
        Assert.IsFalse(putter.PutterControlsEnabled);
    }
}
