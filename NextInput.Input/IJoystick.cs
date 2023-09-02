using System.Numerics;

namespace NextInput.Input;

/// <summary>
/// Base abstraction for a NextInput joystick device
/// </summary>
public interface IJoystick
{
    /// <summary>
    /// This <see cref="IJoystick"/> device information
    /// </summary>
    public JoystickDeviceInformation DeviceInformation { get; }

    /// <summary>
    /// Whether this <see cref="IJoystick"/> is still connected
    /// </summary>
    public bool IsConnected { get; }

    /// <summary>
    /// Get whether a specific button is currently held
    /// <param name="buttonIndex">the index of the button to check</param>
    /// <returns>Whether the button is currently being held or not</returns>
    /// </summary>
    public bool GetButton(int buttonIndex);
    
    /// <summary>
    /// Get the current held state of all buttons on the joystick 
    /// <returns>An array of the buttons current held state</returns>
    /// <remarks>This can in most cases be implemented by simply calling <see cref="GetButton"/> in a for loop</remarks>
    /// </summary>
    public bool[] GetButtons();

    /// <summary>
    /// Get the current value of a specific axis
    /// <param name="axisIndex">the index of the axis to check</param>
    /// <returns>The current axis value in the standardized NextInput axis format</returns>
    /// <seealso cref="Convert"/>
    /// </summary>
    public float GetAxis(int axisIndex);
    
    /// <summary>
    /// Get the current values of all the axes on the joystick 
    /// <returns>An array of the current axes values in the standardized NextInput axis format</returns>
    /// <remarks>This can in most cases be implemented by simply calling <see cref="GetAxis"/> in a for loop</remarks>
    /// <seealso cref="Convert"/>
    /// </summary>
    public float[] GetAxes();
    
    /// <summary>
    /// Get the current hat direction of a specific hat on the joystick
    /// <param name="hatIndex">the index of the hat to check</param>
    /// <returns>The current hat direction</returns>
    /// </summary>
    public JoystickHatDirection GetHat(int hatIndex);
    
    /// <summary>
    /// Get the current hat directions of all the hats on the joystick 
    /// <returns>An array of the current hat directions</returns>
    /// <remarks>This can in most cases be implemented by simply calling <see cref="GetHat"/> in a for loop</remarks>
    /// </summary>
    public JoystickHatDirection[] GetHats();
    
    public JoystickBallState GetBall(int ballIndex);
    
    public JoystickBallState[] GetBalls();
}