namespace NextInput.Input;

/// <summary>
/// Base abstraction for a NextInput game controller device
/// </summary>
public interface IGameController
{
    /// <summary>
    /// This <see cref="IGameController"/> device information
    /// </summary>
    public GameControllerDeviceInformation DeviceInformation { get; }
    
    /// <summary>
    /// Whether this <see cref="IGameController"/> is still connected
    /// </summary>
    public bool IsConnected { get; }

    /// <summary>
    /// Get whether a specific button is currently held
    /// </summary>
    /// <param name="button">The button to check</param>
    /// <remarks>The button needs to be supported by this <see cref="IGameController"/></remarks>
    /// <returns>Whether the button is currently being held or not</returns>
    public bool GetButton(GameControllerButtons button);
    
    /// <summary>
    /// Get all of the currently held buttons
    /// </summary>
    /// <returns>A <see cref="GameControllerButtons"/> value holding the currently held buttons</returns>
    /// <remarks>This only includes the buttons that this <see cref="IGameController"/> supports</remarks>
    /// <seealso cref="GameControllerButtonsExtensions.GetAllFlags"/>
    public GameControllerButtons GetAllHeldButtons();
    
    /// <summary>
    /// Get the held state of all the buttons
    /// </summary>
    /// <returns>A list of <see cref="GameControllerButtons"/> and their held state</returns>
    /// <remarks>This only includes the buttons that this <see cref="IGameController"/> supports</remarks>
    public List<(GameControllerButtons Button, bool IsHeld)> GetAllButtons();
    
    /// <summary>
    /// Get the currently held buttons contained within <paramref name="flags"/>
    /// </summary>
    /// <param name="flags">Restrict the results to only these buttons</param>
    /// <returns>A <see cref="GameControllerButtons"/> value with all of the currently held <see cref="GameControllerButtons"/> contained within <paramref name="flags"/></returns>
    /// <remarks>This only includes the buttons that this <see cref="IGameController"/> supports</remarks>
    /// <seealso cref="GameControllerButtonsExtensions.GetFlags"/>
    public GameControllerButtons GetHeldButtons(GameControllerButtons flags);
    
    /// <summary>
    /// Get the held state for the buttons contained within <paramref name="flags"/>
    /// </summary>
    /// <param name="flags">Restrict the results to only these buttons</param>
    /// <returns>A list of <see cref="GameControllerButtons"/> and their held state contained within <paramref name="flags"/></returns>
    /// <remarks>This only includes the buttons that this <see cref="IGameController"/> supports</remarks>
    public List<(GameControllerButtons Button, bool IsHeld)> GetButtons(GameControllerButtons flags);
    
    /// <summary>
    /// Get the value of a specific axis
    /// </summary>
    /// <param name="axis">The axis to check</param>
    /// <remarks>The axis needs to be supported by this <see cref="IGameController"/></remarks>
    /// <returns>The current axis value in the standardized NextInput axis format</returns>
    public float GetAxis(GameControllerAxes axis);
    
    /// <summary>
    /// Get all of the axes value
    /// </summary>
    /// <returns>A list of <see cref="GameControllerAxes"/> and axis value in the standardized NextInput axis format</returns>
    /// <remarks>This only includes the axes that this <see cref="IGameController"/> supports</remarks>
    public List<(GameControllerAxes Axis, float Value)> GetAllAxes();
    
    /// <summary>
    /// Get all of the axes value contained within <paramref name="flags"/>
    /// </summary>
    /// <param name="flags">Restrict the results to only these axes</param>
    /// <returns>A list of <see cref="GameControllerAxes"/> and axis value in the standardized NextInput axis format contained within <paramref name="flags"/></returns>
    /// <remarks>This only includes the axes that this <see cref="IGameController"/> supports</remarks>
    public List<(GameControllerAxes Axis, float Value)> GetAxes(GameControllerAxes flags);
}