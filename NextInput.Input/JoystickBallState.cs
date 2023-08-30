namespace NextInput.Input;

public struct JoystickBallState
{
    public bool Result { get; }

    public int DeltaX { get; }
    public int DeltaY { get; }

    public JoystickBallState(int result, int deltaX, int deltaY)
    {
        Result = result == 1;
        DeltaX = deltaX;
        DeltaY = deltaY;
    }
}