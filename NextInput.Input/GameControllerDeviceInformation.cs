namespace NextInput.Input;

/// <summary>
/// Class that holds information about a <see cref="IGameController"/> device, used for getting <see cref="IGameController"/> objects
/// <remarks>This class can be inherited if an implementation needs more information about a device</remarks>
/// </summary>
public class GameControllerDeviceInformation : IDeviceInformation
{
    /// <summary>
    /// The name of the game controller device
    /// </summary>
    public string DeviceName { get; }
    
    /// <summary>
    /// The type of the game controller device (brand / model)
    /// </summary>
    public GameControllerDeviceType DeviceType { get; }

    /// <summary>
    /// All the supported buttons by the game controller
    /// <seealso cref="GameControllerButtons"/>
    /// </summary>
    public GameControllerButtons SupportedButtons { get; }
    
    /// <summary>
    /// All the supported axes by the game controller
    /// <seealso cref="GameControllerAxes"/>
    /// </summary>
    public GameControllerAxes SupportedAxes { get; }

    /// <summary>
    /// The public constructor for a <see cref="GameControllerDeviceInformation"/>
    /// </summary>
    /// <param name="deviceName">The name of the device</param>
    /// <param name="deviceType">The type of the device</param>
    /// <param name="supportedButtons">All of the supported buttons by the device<seealso cref="GameControllerButtons"/></param>
    /// <param name="supportedAxes">All of the supported axes by the device <seealso cref="GameControllerAxes"/></param>
    public GameControllerDeviceInformation(string deviceName, GameControllerDeviceType deviceType, GameControllerButtons supportedButtons, GameControllerAxes supportedAxes)
    {
        DeviceName = deviceName;
        DeviceType = deviceType;
        SupportedButtons = supportedButtons;
        SupportedAxes = supportedAxes;
    }
    
    /// <summary>
    /// Checks whether the 2 <see cref="GameControllerDeviceInformation"/> are equal
    /// </summary>
    /// <param name="first">The first object to compare</param>
    /// <param name="second">The second object to compare</param>
    /// <returns>Whether the two <see cref="GameControllerDeviceInformation"/> are equal</returns>
    public static bool operator ==(GameControllerDeviceInformation? first, GameControllerDeviceInformation? second)
    {
        if (first is null || second is null)
            return first is null && second is null;

        return first.DeviceName == second.DeviceName &&
               first.DeviceType == second.DeviceType &&
               first.SupportedAxes == second.SupportedAxes &&
               first.SupportedButtons == second.SupportedButtons;
    }

    /// <summary>
    /// Checks whether the 2 <see cref="GameControllerDeviceInformation"/> are not equal
    /// </summary>
    /// <param name="first">The first object to compare</param>
    /// <param name="second">The second object to compare</param>
    /// <returns>Whether the two <see cref="GameControllerDeviceInformation"/> are not equal</returns>
    public static bool operator !=(GameControllerDeviceInformation? first, GameControllerDeviceInformation? second)
    {
        return !(first == second);
    }
}