// TODO!
namespace NextInput.Input;

public class GameControllerDeviceInformation : IDeviceInformation
{
    public string DeviceName { get; }
    
    public GameControllerDeviceType DeviceType { get; }

    public GameControllerDeviceInformation(string deviceName, GameControllerDeviceType deviceType)
    {
        DeviceName = deviceName;
        DeviceType = deviceType;
    }
}