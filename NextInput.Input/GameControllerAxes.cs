namespace NextInput.Input;

[Flags]
public enum GameControllerAxes
{
    Unknown = 1 << 31,
    LeftX = 1 << 0,
    LeftY = 1 << 1,
    RightX = 1 << 2,
    RightY = 1 << 3,
    TriggerLeft = 1 << 4,
    TriggerRight = 1 << 5
}