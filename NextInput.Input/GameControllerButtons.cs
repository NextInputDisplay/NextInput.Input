namespace NextInput.Input;

[Flags]
public enum GameControllerButtons
{
    Unknown = 1 << 31,
    A = 1 << 0,
    B = 1 << 1,
    X = 1 << 2,
    Y = 1 << 3,
    Back = 1 << 4,
    Guide = 1 << 5,
    Start = 1 << 6,
    LeftStick = 1 << 7,
    RightStick = 1 << 8,
    LeftShoulder = 1 << 9,
    RightShoulder = 1 << 10,
    DPadUp = 1 << 11,
    DPadDown = 1 << 12,
    DPadLeft = 1 << 13,
    DPadRight = 1 << 14,
    PaddleOne = 1 << 15,
    PaddleTwo = 1 << 16,
    PaddleThree = 1 << 17,
    PaddleFour = 1 << 18,
    TouchPad = 1 << 19,
    MiscellaneousOne = 1 << 20
}