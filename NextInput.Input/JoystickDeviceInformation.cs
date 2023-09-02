namespace NextInput.Input;

/// <summary>
/// Class that holds information about a <see cref="IJoystick"/> device, used for getting <see cref="IJoystick"/> objects
/// <remarks>This class can be inherited if an implementation needs more information about a device</remarks>
/// </summary>
public class JoystickDeviceInformation : IDeviceInformation
{
    /// <summary>
    /// The name of the joystick device
    /// </summary>
    public string DeviceName { get; }
    
    /// <summary>
    /// The number of buttons this device has
    /// </summary>
    public uint DeviceButtonsCount { get; }
    
    /// <summary>
    /// The number of axes this device has
    /// </summary>
    public uint DeviceAxesCount { get; }
    
    /// <summary>
    /// The number of balls this device has
    /// </summary>
    public uint DeviceBallsCount { get; }
    
    /// <summary>
    /// The number of hats this device has
    /// </summary>
    public uint DeviceHatsCount { get; }

    /// <summary>
    /// The public constructor for a <see cref="JoystickDeviceInformation"/>
    /// </summary>
    /// <param name="deviceName">The name of the device</param>
    /// <param name="deviceButtonsCount">The number of buttons this device has</param>
    /// <param name="deviceAxesCount">The number of axes this device has</param>
    /// <param name="deviceBallsCount">The number of balls this device has</param>
    /// <param name="deviceHatsCount">The number of hats this device has</param>
    public JoystickDeviceInformation(string deviceName, uint deviceButtonsCount, uint deviceAxesCount, uint deviceBallsCount, uint deviceHatsCount)
    {
        DeviceName = deviceName;
        DeviceButtonsCount = deviceButtonsCount;
        DeviceAxesCount = deviceAxesCount;
        DeviceBallsCount = deviceBallsCount;
        DeviceHatsCount = deviceHatsCount;
    }
    
    /// <summary>
    /// Checks whether the 2 <see cref="JoystickDeviceInformation"/> are equal
    /// </summary>
    /// <param name="first">The first object to compare</param>
    /// <param name="second">The second object to compare</param>
    /// <returns>Whether the two <see cref="JoystickDeviceInformation"/> are equal</returns>
    public static bool operator ==(JoystickDeviceInformation? first, JoystickDeviceInformation? second)
    {
        if (first is null || second is null)
            return first is null && second is null;

        return first.DeviceName == second.DeviceName &&
           first.DeviceButtonsCount == second.DeviceButtonsCount &&
           first.DeviceAxesCount == second.DeviceAxesCount &&
           first.DeviceHatsCount == second.DeviceHatsCount &&
           first.DeviceBallsCount == second.DeviceBallsCount;
    }

    /// <summary>
    /// Checks whether the 2 <see cref="JoystickDeviceInformation"/> are not equal
    /// </summary>
    /// <param name="first">The first object to compare</param>
    /// <param name="second">The second object to compare</param>
    /// <returns>Whether the two <see cref="JoystickDeviceInformation"/> are not equal</returns>
    public static bool operator !=(JoystickDeviceInformation? first, JoystickDeviceInformation? second)
    {
        return !(first == second);
    }
}