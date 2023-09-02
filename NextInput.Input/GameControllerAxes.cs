namespace NextInput.Input;

/// <summary>
/// Enum representing a NextInput GameController axis
/// <remarks>A single value of this enum can be used to store multiple <see cref="GameControllerAxes"/> as each axis option represents 1 bit</remarks>
/// <example>var gameControllerAxes = <see cref="GameControllerAxes.LeftX"/> | <see cref="GameControllerAxes.LeftY"/></example>
/// </summary>
[Flags]
public enum GameControllerAxes
{
    /// <summary>
    /// Represents an unknown <see cref="GameControllerAxes"/>
    /// </summary>
    Unknown = 1 << 31,
    /// <summary>
    /// Represents the X axis on the left stick
    /// </summary>
    LeftX = 1 << 0,
    /// <summary>
    /// Represents the Y axis on the left stick
    /// </summary>
    LeftY = 1 << 1,
    /// <summary>
    /// Represents the X axis on the right stick
    /// </summary>
    RightX = 1 << 2,
    /// <summary>
    /// Represents the Y axis on the right stick
    /// </summary>
    RightY = 1 << 3,
    /// <summary>
    /// Represents the left trigger (LT) axis
    /// </summary>
    TriggerLeft = 1 << 4,
    /// <summary>
    /// Represents the right trigger (RT) axis
    /// </summary>
    TriggerRight = 1 << 5
}