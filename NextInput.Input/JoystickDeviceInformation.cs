namespace NextInput.Input;

public class JoystickDeviceInformation : IDeviceInformation
{
    public string DeviceName { get; }
    public uint DeviceButtonsCount { get; }
    public uint DeviceAxesCount { get; }
    public uint DeviceBallsCount { get; }
    public uint DeviceHatsCount { get; }

    public JoystickDeviceInformation(string deviceName, uint deviceButtonsCount, uint deviceAxesCount, uint deviceBallsCount, uint deviceHatsCount)
    {
        DeviceName = deviceName;
        DeviceButtonsCount = deviceButtonsCount;
        DeviceAxesCount = deviceAxesCount;
        DeviceBallsCount = deviceBallsCount;
        DeviceHatsCount = deviceHatsCount;
    }
    
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

    public static bool operator !=(JoystickDeviceInformation? first, JoystickDeviceInformation? second)
    {
        return !(first == second);
    }
}