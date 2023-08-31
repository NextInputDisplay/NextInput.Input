using static SDL2.SDL;

namespace NextInput.Input.SDL;

public class SDLInputBackend : IInputBackend
{
    private SDLInputBackend()
    {
        SDL_Init(SDL_INIT_JOYSTICK | SDL_INIT_EVENTS | SDL_INIT_GAMECONTROLLER);
    }
    
    public static IInputBackend CreateInputBackend()
    {
        return new SDLInputBackend();
    }

    public static string InputBackendName => "SDL Input Backend";
    
    public static bool IsJoystickSupported => true;
    public static bool IsGameControllerSupported => true;
    public static bool IsMouseSupported => false;
    public static bool IsKeyboardSupported => false;

    public IEnumerable<JoystickDeviceInformation> Joysticks => GetJoysticksDeviceInformation(); 
    public IEnumerable<GameControllerDeviceInformation> GameControllers => throw new NotImplementedException("TODO!");
    
    public IEnumerable<MouseDeviceInformation> Mice => Enumerable.Empty<MouseDeviceInformation>();
    public IEnumerable<KeyboardDeviceInformation> Keyboards => Enumerable.Empty<KeyboardDeviceInformation>();

    private IEnumerable<JoystickDeviceInformation> GetJoysticksDeviceInformation()
    {
        int joysticksNumber = SDL_NumJoysticks();

        JoystickDeviceInformation[] joystickDevicesInformation = new JoystickDeviceInformation[joysticksNumber];

        for (int i = 0; i < joysticksNumber; i++)
            joystickDevicesInformation[i] = GetJoystickDeviceInformation(i);

        return joystickDevicesInformation;
    }

    private JoystickDeviceInformation GetJoystickDeviceInformation(int joystickIndex)
    {
        IntPtr joystick = SDL_JoystickOpen(joystickIndex);

        string joystickName = SDL_JoystickName(joystick);
        uint joystickButtonCount = (uint)SDL_JoystickNumButtons(joystick);
        uint joystickAxesCount = (uint)SDL_JoystickNumAxes(joystick);
        uint joystickHatCount = (uint)SDL_JoystickNumHats(joystick);
        uint joystickBallCount = (uint)SDL_JoystickNumBalls(joystick);

        return new JoystickDeviceInformation(joystickName, joystickButtonCount, joystickAxesCount, joystickBallCount,
            joystickHatCount);
    }

    public IJoystick GetJoystick(JoystickDeviceInformation joystickToOpen)
    {
        List<JoystickDeviceInformation> joysticks = GetJoysticksDeviceInformation().ToList();

        for (int i = 0; i < joysticks.Count; i++)
            if (joysticks[i] == joystickToOpen)
                return new SDLJoystick(i, joysticks[i]);

        throw new Exception("Controller was disconnected?");
    }
    
    public void UpdateJoysticks() => SDL_JoystickUpdate();
    public void DisposeJoystick(IJoystick joystick) => SDL_JoystickClose(((SDLJoystick)joystick).JoystickPtr);

    public IGameController GetGameController(GameControllerDeviceInformation gameControllerToOpen)
    {
        throw new NotImplementedException("TODO!");
    }

    public IMouse GetMouse(MouseDeviceInformation mouseToOpen)
    {
        throw new NotSupportedException("The SDL Input Backend does not support mice");
    }

    public IKeyboard GetKeyboard(KeyboardDeviceInformation keyboardToOpen)
    {
        throw new NotSupportedException("The SDL Input Backend does not support keyboards");
    }
}