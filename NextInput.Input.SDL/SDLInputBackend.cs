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
    public IEnumerable<GameControllerDeviceInformation> GameControllers => GetGameControllersDeviceInformation();
    
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
        
        SDL_JoystickClose(joystick);

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

    private const int MaxGameControllers = 8;

    private IEnumerable<GameControllerDeviceInformation> GetGameControllersDeviceInformation()
    {
        int gameControllersNumber = MaxGameControllers;

        List<GameControllerDeviceInformation> gameControllersDeviceInformation = new List<GameControllerDeviceInformation>();

        for (int i = 0; i < gameControllersNumber; i++)
        {
            IntPtr controllerPtr = SDL_GameControllerOpen(i);

            if (controllerPtr != IntPtr.Zero)
            {
                gameControllersDeviceInformation.Add(GetGameControllerDeviceInformation(i, controllerPtr));
                SDL_GameControllerClose(controllerPtr);
            }
        }

        return gameControllersDeviceInformation;
    }
    
    private GameControllerDeviceInformation GetGameControllerDeviceInformation(int joystickIndex, IntPtr controllerPtr)
    {
        string controllerName = SDL_GameControllerName(controllerPtr);
        GameControllerDeviceType controllerType = SDL_GameControllerGetType(controllerPtr) switch
        {
            SDL_GameControllerType.SDL_CONTROLLER_TYPE_UNKNOWN => GameControllerDeviceType.Unknown,
            SDL_GameControllerType.SDL_CONTROLLER_TYPE_XBOX360 => GameControllerDeviceType.Xbox360,
            SDL_GameControllerType.SDL_CONTROLLER_TYPE_XBOXONE => GameControllerDeviceType.XboxOne,
            SDL_GameControllerType.SDL_CONTROLLER_TYPE_PS3 => GameControllerDeviceType.PlayStation3,
            SDL_GameControllerType.SDL_CONTROLLER_TYPE_PS4 => GameControllerDeviceType.PlayStation4,
            SDL_GameControllerType.SDL_CONTROLLER_TYPE_PS5 => GameControllerDeviceType.PlayStation5,
            SDL_GameControllerType.SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_PRO => GameControllerDeviceType.NintendoSwitchPro,
            SDL_GameControllerType.SDL_CONTROLLER_TYPE_VIRTUAL => GameControllerDeviceType.Virtual,
            SDL_GameControllerType.SDL_CONTROLLER_TYPE_AMAZON_LUNA => GameControllerDeviceType.AmazonLuna,
            SDL_GameControllerType.SDL_CONTROLLER_TYPE_GOOGLE_STADIA => GameControllerDeviceType.GoogleStadia,
            _ => throw new ArgumentOutOfRangeException()
        };

        GameControllerButtons supportedButtons = GameControllerButtons.None;
        GameControllerAxes supportedAxes = GameControllerAxes.None;

        foreach (SDL_GameControllerButton sdlButton in Enum.GetValues<SDL_GameControllerButton>())
        {
            if (sdlButton is SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_MAX or SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_INVALID)
                continue;

            if (SDL_GameControllerHasButton(controllerPtr, sdlButton) == SDL_bool.SDL_TRUE)
                supportedButtons |= sdlButton.ToGameControllerButtons();
        }
        
        foreach (SDL_GameControllerAxis sdlAxis in Enum.GetValues<SDL_GameControllerButton>())
        {
            if (sdlAxis is SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_MAX or SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_INVALID)
                continue;

            if (SDL_GameControllerHasAxis(controllerPtr, sdlAxis) == SDL_bool.SDL_TRUE)
                supportedAxes |= sdlAxis.ToGameControllerAxes();
        }
        
        return new GameControllerDeviceInformation(controllerName, controllerType, supportedButtons, supportedAxes);
    }
    
    public IGameController GetGameController(GameControllerDeviceInformation gameControllerToOpen)
    {
        List<GameControllerDeviceInformation> gameControllers = GetGameControllersDeviceInformation().ToList();

        for (int i = 0; i < gameControllers.Count; i++)
            if (gameControllers[i] == gameControllerToOpen)
                return new SDLGameController(i, gameControllers[i]);

        throw new Exception("Controller was disconnected?");
    }

    public void UpdateGameControllers() => SDL_GameControllerUpdate();
    
    public void DisposeGameController(IGameController gameController) => SDL_GameControllerClose(((SDLGameController)gameController).GameControllerPtr);

    public IMouse GetMouse(MouseDeviceInformation mouseToOpen)
    {
        throw new NotSupportedException("The SDL Input Backend does not support mice");
    }

    public IKeyboard GetKeyboard(KeyboardDeviceInformation keyboardToOpen)
    {
        throw new NotSupportedException("The SDL Input Backend does not support keyboards");
    }
}