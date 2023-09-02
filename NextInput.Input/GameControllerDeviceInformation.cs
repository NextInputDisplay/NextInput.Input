namespace NextInput.Input;

public class GameControllerDeviceInformation : IDeviceInformation
{
    public string DeviceName { get; }
    
    public GameControllerDeviceType DeviceType { get; }

    public GameControllerButtons SupportedButtons { get; }
    
    public GameControllerAxes SupportedAxes { get; }

    public GameControllerDeviceInformation(string deviceName, GameControllerDeviceType deviceType, GameControllerButtons supportedButtons, GameControllerAxes supportedAxes)
    {
        DeviceName = deviceName;
        DeviceType = deviceType;
        SupportedButtons = supportedButtons;
        SupportedAxes = supportedAxes;
    }
}