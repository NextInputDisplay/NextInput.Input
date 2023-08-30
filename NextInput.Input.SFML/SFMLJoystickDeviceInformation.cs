using SFML.Window;

namespace NextInput.Input.SFML;

public class SFMLJoystickDeviceInformation : JoystickDeviceInformation
{
    internal Joystick.Axis[] SupportedAxes;
    
    public SFMLJoystickDeviceInformation(string deviceName, uint deviceButtonsCount, Joystick.Axis[] supportedAxes) : base(deviceName, deviceButtonsCount, (uint)supportedAxes.Length, 0, 0)
    {
        SupportedAxes = supportedAxes;
    }
}