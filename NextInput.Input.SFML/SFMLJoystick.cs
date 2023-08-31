using SFML.Window;

namespace NextInput.Input.SFML;

public class SFMLJoystick : IJoystick
{
    internal uint _joystickIndex;
    
    internal SFMLJoystick(uint joystickIndex, SFMLJoystickDeviceInformation deviceInformation)
    {
        DeviceInformation = deviceInformation;
        _joystickIndex = joystickIndex;
    }
    
    public JoystickDeviceInformation DeviceInformation { get; }
    public bool IsConnected => Joystick.IsConnected(_joystickIndex);
    public bool GetButton(int buttonIndex) => Joystick.IsButtonPressed(_joystickIndex, (uint)buttonIndex);

    public bool[] GetButtons()
    {
        bool[] buttons = new bool[DeviceInformation.DeviceButtonsCount];

        for (int i = 0; i < buttons.Length; i++)
            buttons[i] = GetButton(i);

        return buttons;
    }

    public float GetAxis(int axisIndex)
    {
        return (Joystick.GetAxisPosition(_joystickIndex,
            ((SFMLJoystickDeviceInformation)DeviceInformation).SupportedAxes[axisIndex]) + 100f) / 200f;
    }

    public float[] GetAxes()
    {
        float[] axes = new float[DeviceInformation.DeviceAxesCount];

        for (int i = 0; i < axes.Length; i++)
            axes[i] = GetAxis(i);

        return axes;
    }

    public JoystickHatDirection GetHat(int hatIndex)
    {
        throw new NotSupportedException();
    }

    public JoystickHatDirection[] GetHats()
    {
        return Array.Empty<JoystickHatDirection>();
    }

    public JoystickBallState GetBall(int ballIndex)
    {
        throw new NotSupportedException();
    }

    public JoystickBallState[] GetBalls()
    {
        return Array.Empty<JoystickBallState>();
    }
}