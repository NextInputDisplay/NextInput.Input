using System.Numerics;
using static SDL2.SDL;

namespace NextInput.Input.SDL;

public class SDLJoystick : IJoystick
{
    private IntPtr _joystickPtr;
    
    internal SDLJoystick(int joystickIndex, JoystickDeviceInformation deviceInformation)
    {
        DeviceInformation = deviceInformation;

        _joystickPtr = SDL_JoystickOpen(joystickIndex);
    }
    
    public JoystickDeviceInformation DeviceInformation { get; }
    
    public bool GetButton(int buttonIndex) => SDL_JoystickGetButton(_joystickPtr, buttonIndex) == 1;

    public bool[] GetButtons()
    {
        bool[] buttons = new bool[DeviceInformation.DeviceButtonsCount];

        for (int i = 0; i < buttons.Length; i++)
            buttons[i] = GetButton(i);

        return buttons;
    }

    public float GetAxis(int axisIndex) => Convert.ToAxis(SDL_JoystickGetAxis(_joystickPtr, axisIndex));

    public float[] GetAxes()
    {
        float[] axes = new float[DeviceInformation.DeviceAxesCount];

        for (int i = 0; i < axes.Length; i++)
            axes[i] = GetAxis(i);

        return axes;
    }

    public JoystickHatDirection GetHat(int hatIndex)
    {
        return SDL_JoystickGetHat(_joystickPtr, hatIndex) switch
        {
            SDL_HAT_CENTERED => JoystickHatDirection.Centered,
            SDL_HAT_UP => JoystickHatDirection.Up,
            SDL_HAT_RIGHT => JoystickHatDirection.Right,
            SDL_HAT_DOWN => JoystickHatDirection.Down,
            SDL_HAT_LEFT => JoystickHatDirection.Left,
            SDL_HAT_RIGHTUP => JoystickHatDirection.RightUp,
            SDL_HAT_RIGHTDOWN => JoystickHatDirection.RightDown,
            SDL_HAT_LEFTUP => JoystickHatDirection.LeftUp,
            SDL_HAT_LEFTDOWN => JoystickHatDirection.LeftDown,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public JoystickHatDirection[] GetHats()
    {
        JoystickHatDirection[] hats = new JoystickHatDirection[DeviceInformation.DeviceHatsCount];

        for (int i = 0; i < hats.Length; i++)
            hats[i] = GetHat(i);

        return hats;
    }

    public JoystickBallState GetBall(int ballIndex)
    {
        int result = SDL_JoystickGetBall(_joystickPtr, ballIndex, out int deltaX, out int deltaY);
        return new JoystickBallState(result, deltaX, deltaY);
    }

    public JoystickBallState[] GetBalls()
    {
        JoystickBallState[] balls = new JoystickBallState[DeviceInformation.DeviceBallsCount];
        
        for (int i = 0; i < balls.Length; i++)
            balls[i] = GetBall(i);

        return balls;
    }

    internal void Close()
    {
        SDL_JoystickClose(_joystickPtr);
    }
}