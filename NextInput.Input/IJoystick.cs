using System.Numerics;

namespace NextInput.Input;

public interface IJoystick
{
    public JoystickDeviceInformation DeviceInformation { get; }

    public bool GetButton(int buttonIndex);
    
    public bool[] GetButtons();

    public float GetAxis(int axisIndex);
    
    public float[] GetAxes();
    
    public JoystickHatDirection GetHat(int hatIndex);
    
    public JoystickHatDirection[] GetHats();
    
    public JoystickBallState GetBall(int ballIndex);
    
    public JoystickBallState[] GetBalls();
}