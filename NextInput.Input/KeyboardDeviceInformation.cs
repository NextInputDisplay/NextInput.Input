// TODO!
namespace NextInput.Input;

public class KeyboardDeviceInformation : IDeviceInformation
{
    public string DeviceName { get; }
    
    public KeyboardDeviceInformation(string deviceName)
    {
        DeviceName = deviceName;
    }
}
