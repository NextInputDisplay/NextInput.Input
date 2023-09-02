using SFML.Window;

namespace NextInput.Input.SFML;

public class SFMLInputBackend : IInputBackend
{
    private SFMLInputBackend() { }
    
    public static IInputBackend CreateInputBackend()
    {
        return new SFMLInputBackend();
    }

    public static string InputBackendName => "SFML Input Backend";
    public static bool IsJoystickSupported => true;
    public static bool IsGameControllerSupported => false;
    public static bool IsMouseSupported => false;
    public static bool IsKeyboardSupported => false;
    public IEnumerable<JoystickDeviceInformation> Joysticks => GetJoysticksDeviceInformation();
    public IEnumerable<GameControllerDeviceInformation> GameControllers => throw new NotSupportedException("The SFML Input Backend does not support game controllers");
    public IEnumerable<MouseDeviceInformation> Mice => throw new NotSupportedException("The SFML Input Backend does not support mice");
    public IEnumerable<KeyboardDeviceInformation> Keyboards => throw new NotSupportedException("The SFML Input Backend does not support keyboards");
    
    private IEnumerable<SFMLJoystickDeviceInformation> GetJoysticksDeviceInformation()
    {
        uint joysticksNumber = Joystick.Count;

        List<SFMLJoystickDeviceInformation> joystickDevicesInformation = new List<SFMLJoystickDeviceInformation>();
        
        for (uint i = 0; i < joysticksNumber; i++)
        {
            if (Joystick.IsConnected(i))
                joystickDevicesInformation.Add(GetJoystickDeviceInformation(i));
        }

        return joystickDevicesInformation;
    }
    
    private SFMLJoystickDeviceInformation GetJoystickDeviceInformation(uint joystickIndex)
    {
        Joystick.Identification id = Joystick.GetIdentification(joystickIndex);

        string joystickName = id.Name;
        
        uint joystickButtonCount = Joystick.GetButtonCount(joystickIndex);

        List<Joystick.Axis> supportedAxes = new List<Joystick.Axis>();
        
        foreach (Joystick.Axis axis in Enum.GetValues<Joystick.Axis>())
            if (Joystick.HasAxis(joystickIndex, axis))
                supportedAxes.Add(axis);

        return new SFMLJoystickDeviceInformation(joystickName, joystickButtonCount, supportedAxes.ToArray());
    }
    
    public IJoystick GetJoystick(JoystickDeviceInformation joystickToOpen)
    {
        List<SFMLJoystickDeviceInformation> joysticks = GetJoysticksDeviceInformation().ToList();

        for (int i = 0; i < joysticks.Count; i++)
            if (joysticks[i] == joystickToOpen)
                return new SFMLJoystick((uint)i, joysticks[i]);

        throw new Exception("Controller was disconnected?");
    }
    
    public void UpdateJoysticks()
    {
        Joystick.Update();
    }

    public void DisposeJoystick(IJoystick joystick)
    {
        ((SFMLJoystick)joystick)._joystickIndex = uint.MaxValue;
    }

    public IGameController GetGameController(GameControllerDeviceInformation gameControllerToOpen)
    {
        throw new NotSupportedException("The SFML Input Backend does not support game controllers");
    }

    public void UpdateGameControllers()
    {
        throw new NotSupportedException("The SFML Input Backend does not support game controllers");
    }

    public IMouse GetMouse(MouseDeviceInformation mouseToOpen)
    {
        throw new NotSupportedException("The SFML Input Backend does not support mice");
    }

    public IKeyboard GetKeyboard(KeyboardDeviceInformation keyboardToOpen)
    {
        throw new NotSupportedException("The SFML Input Backend does not support keyboards");
    }
}