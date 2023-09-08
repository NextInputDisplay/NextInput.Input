namespace NextInput.Input;

/// <summary>
/// Enum representing a NextInput GameController button
/// <remarks>A single value of this enum can be used to store multiple <see cref="GameControllerButtons"/> as each button option represents 1 bit</remarks>
/// <example>var gameControllerButtons = <see cref="GameControllerButtons.A"/> | <see cref="GameControllerButtons.B"/></example>
/// </summary>
[Flags]
public enum GameControllerButtons
{
    /// <summary>
    /// Represents an unknown <see cref="GameControllerButtons"/>
    /// </summary>
    Unknown = 1 << 31,
    /// <summary>
    /// Represents no button
    /// </summary>
    None = 0,
    /// <summary>
    /// Represents the A face button
    /// </summary>
    A = 1 << 0,
    /// <summary>
    /// Represents the B face button
    /// </summary>
    B = 1 << 1,
    /// <summary>
    /// Represents the X face button
    /// </summary>
    X = 1 << 2,
    /// <summary>
    /// Represents the Y face button
    /// </summary>
    Y = 1 << 3,
    /// <summary>
    /// Represents the Back button (also known as Select)
    /// </summary>
    Back = 1 << 4,
    /// <summary>
    /// Represents the Guide button (also known as the PlayStation button, Xbox button, etc...)
    /// </summary>
    Guide = 1 << 5,
    /// <summary>
    /// Represents the Start button
    /// </summary>
    Start = 1 << 6,
    /// <summary>
    /// Represents a click on the left stick button (also known as L3)
    /// </summary>
    LeftStick = 1 << 7,
    /// <summary>
    /// Represents a click on the right stick button (also known as R3)
    /// </summary>
    RightStick = 1 << 8,
    /// <summary>
    /// Represents the left shoulder button (also known as LB)
    /// </summary>
    LeftShoulder = 1 << 9,
    /// <summary>
    /// Represents the right shoulder button (also known as RB)
    /// </summary>
    RightShoulder = 1 << 10,
    /// <summary>
    /// Represents the up direction on a 4 directional pad
    /// </summary>
    DPadUp = 1 << 11,
    /// <summary>
    /// Represents the down direction on a 4 directional pad
    /// </summary>
    DPadDown = 1 << 12,
    /// <summary>
    /// Represents the left direction on a 4 directional pad
    /// </summary>
    DPadLeft = 1 << 13,
    /// <summary>
    /// Represents the right direction on a 4 directional pad
    /// </summary>
    DPadRight = 1 << 14,
    /// <summary>
    /// Represents the first paddle (usually located at the back of a controller)
    /// </summary>
    PaddleOne = 1 << 15,
    /// <summary>
    /// Represents the second paddle (usually located at the back of a controller)
    /// </summary>
    PaddleTwo = 1 << 16,
    /// <summary>
    /// Represents the third paddle (usually located at the back of a controller)
    /// </summary>
    PaddleThree = 1 << 17,
    /// <summary>
    /// Represents the fourth paddle (usually located at the back of a controller)
    /// </summary>
    PaddleFour = 1 << 18,
    /// <summary>
    /// Represents the touchpad button
    /// </summary>
    TouchPad = 1 << 19,
    /// <summary>
    /// Represents a miscellaneous button
    /// </summary>
    MiscellaneousOne = 1 << 20
}