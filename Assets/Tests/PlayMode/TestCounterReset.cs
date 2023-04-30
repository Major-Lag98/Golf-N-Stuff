using NUnit.Framework;

public class TestCounterReset
{
    [Test]
    public void TestResetCounter()
    {
        // create a new GameStateMachine object
        GameStateMachine gameStateMachine = new GameStateMachine();

        // set WaitIdleTime to 1.0f
        gameStateMachine.WaitIdleTime = 1.0f;

        // call resetCounter function
        gameStateMachine.resetCounter();

        // check that WaitIdleTime is equal to 0.0f
        Assert.AreEqual(0.0f, gameStateMachine.WaitIdleTime);

        // set WaitIdleTime to 2.5f
        gameStateMachine.WaitIdleTime = 2.5f;

        // call resetCounter function
        gameStateMachine.resetCounter();

        // check that WaitIdleTime is equal to 0.0f
        Assert.AreEqual(0.0f, gameStateMachine.WaitIdleTime);

        // set WaitIdleTime to 0.5f
        gameStateMachine.WaitIdleTime = 0.5f;

        // call resetCounter function
        gameStateMachine.resetCounter();

        // check that WaitIdleTime is equal to 0.0f
        Assert.AreEqual(0.0f, gameStateMachine.WaitIdleTime);
    }
}
