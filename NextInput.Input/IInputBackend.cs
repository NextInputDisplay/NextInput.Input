using System.Numerics;

namespace NextInput.Input;

/// <summary>
/// The base abstraction for an input backend
/// </summary>
public interface IInputBackend
{
    /// <summary>
    /// This will be called to retrieve an input backend implementation
    /// </summary>
    /// <returns>An instance of an input backend implementation</returns>
    public static abstract IInputBackend CreateInputBackend();

    /// <summary>
    /// The name of the input backend
    /// <remarks>This will be used as the identifier when a specific backend is requested</remarks>
    /// </summary>
    public static abstract string InputBackendName { get; }
    
    /// <summary>
    /// Whether the input backend implementation supports joystick devices
    /// </summary>
    public static abstract bool IsJoystickSupported { get; }
    /// <summary>
    /// Whether the input backend implementation supports game controller devices
    /// </summary>
    public static abstract bool IsGameControllerSupported { get; }
    /// <summary>
    /// Whether the input backend implementation supports mouse devices
    /// </summary>
    public static abstract bool IsMouseSupported { get; }
    /// <summary>
    /// Whether the input backend implementation supports keyboard devices
    /// </summary>
    public static abstract bool IsKeyboardSupported { get; }
    
    /// <summary>
    /// Getter for all the joystick devices information (if supported by the backend)
    /// <remarks>This should return a <see cref="JoystickDeviceInformation"/> for each connected and supported joystick device</remarks>
    /// </summary>
    public IEnumerable<JoystickDeviceInformation> Joysticks { get; }
    /// <summary>
    /// Getter for all the game controller devices information (if supported by the backend)
    /// <remarks>This should return a <see cref="GameControllerDeviceInformation"/> for each connected and supported game controller device</remarks>
    /// </summary>
    public IEnumerable<GameControllerDeviceInformation> GameControllers { get; }
    /// <summary>
    /// Getter for all the mouse devices information (if supported by the backend)
    /// <remarks>This should return a <see cref="MouseDeviceInformation"/> for each connected and supported mouse device</remarks>
    /// </summary>
    public IEnumerable<MouseDeviceInformation> Mice { get; }
    /// <summary>
    /// Getter for all the keyboard devices information (if supported by the backend)
    /// <remarks>This should return a <see cref="KeyboardDeviceInformation"/> for each connected and supported keyboard device</remarks>
    /// </summary>
    public IEnumerable<KeyboardDeviceInformation> Keyboards { get; }

    /// <summary>
    /// Get a <see cref="IJoystick"/> instance with the provided <paramref name="joystickToOpen"/>
    /// </summary>
    /// <param name="joystickToOpen">The <see cref="JoystickDeviceInformation"/> that was queried using the <see cref="Joysticks"/> getter</param>
    /// <returns>An instance of a <see cref="IJoystick"/> implementation</returns>
    public IJoystick GetJoystick(JoystickDeviceInformation joystickToOpen);
    /// <summary>
    /// Frequently called method that can be used to refresh the <see cref="IJoystick"/>'s state / values
    /// </summary>
    public void UpdateJoysticks();
    /// <summary>
    /// Method called to dispose of the <see cref="IJoystick"/> resources
    /// </summary>
    /// <param name="joystick">The <see cref="IJoystick"/> instance to be disposed</param>
    public void DisposeJoystick(IJoystick joystick);
    
    /// <summary>
    /// Get a <see cref="IGameController"/> instance with the provided <paramref name="gameControllerToOpen"/>
    /// </summary>
    /// <param name="gameControllerToOpen">The <see cref="GameControllerDeviceInformation"/> that was queried using the <see cref="GameControllers"/> getter</param>
    /// <returns>An instance of a <see cref="IGameController"/> implementation</returns>
    public IGameController GetGameController(GameControllerDeviceInformation gameControllerToOpen);
    /// <summary>
    /// Frequently called method that can be used to refresh the <see cref="IGameController"/>'s state / values
    /// </summary>
    public void UpdateGameControllers();
    
    /// <summary>
    /// Get a <see cref="IMouse"/> instance with the provided <paramref name="mouseToOpen"/>
    /// </summary>
    /// <param name="mouseToOpen">The <see cref="MouseDeviceInformation"/> that was queried using the <see cref="Mice"/> getter</param>
    /// <returns>An instance of a <see cref="IMouse"/> implementation</returns>
    public IMouse GetMouse(MouseDeviceInformation mouseToOpen);
    
    /// <summary>
    /// Get a <see cref="IKeyboard"/> instance with the provided <paramref name="keyboardToOpen"/>
    /// </summary>
    /// <param name="keyboardToOpen">The <see cref="KeyboardDeviceInformation"/> that was queried using the <see cref="Keyboards"/> getter</param>
    /// <returns>An instance of a <see cref="IKeyboard"/> implementation</returns>
    public IKeyboard GetKeyboard(KeyboardDeviceInformation keyboardToOpen);
}