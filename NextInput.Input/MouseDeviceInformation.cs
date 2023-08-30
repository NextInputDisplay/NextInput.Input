// TODO!
namespace NextInput.Input;

public class MouseDeviceInformation : IDeviceInformation
{
    public string DeviceName { get; }

    public MouseDeviceInformation(string deviceName)
    {
        DeviceName = deviceName;
    }
}