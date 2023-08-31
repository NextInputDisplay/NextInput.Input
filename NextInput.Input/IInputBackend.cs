using System.Numerics;

namespace NextInput.Input;

public interface IInputBackend
{
    public static abstract IInputBackend CreateInputBackend();

    public static abstract string InputBackendName { get; }
    
    public static abstract bool IsJoystickSupported { get; }
    public static abstract bool IsGameControllerSupported { get; }
    public static abstract bool IsMouseSupported { get; }
    public static abstract bool IsKeyboardSupported { get; }
    
    public IEnumerable<JoystickDeviceInformation> Joysticks { get; }
    public IEnumerable<GameControllerDeviceInformation> GameControllers { get; }
    public IEnumerable<MouseDeviceInformation> Mice { get; }
    public IEnumerable<KeyboardDeviceInformation> Keyboards { get; }

    public IJoystick GetJoystick(JoystickDeviceInformation joystickToOpen);
    public void UpdateJoysticks();
    public void DisposeJoystick(IJoystick joystick);
    public IGameController GetGameController(GameControllerDeviceInformation gameControllerToOpen);
    public IMouse GetMouse(MouseDeviceInformation mouseToOpen);
    public IKeyboard GetKeyboard(KeyboardDeviceInformation keyboardToOpen);
}