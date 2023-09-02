namespace NextInput.Input;

/// <summary>
/// Static class providing helpers to work with <see cref="GameControllerButtons"/>
/// </summary>
public static class GameControllerButtonsExtensions
{
    private static GameControllerButtons[] _buttonsEnum = Enum.GetValues<GameControllerButtons>();
    
    /// <summary>
    /// Get the possible multiple buttons that <paramref name="buttons"/> contains
    /// <param name="buttons">A <see cref="GameControllerButtons"/> that holds 1 or more buttons</param>
    /// <returns>A collection of the <see cref="GameControllerButtons"/> retrieved from <paramref name="buttons"/></returns>
    /// </summary>
    public static List<GameControllerButtons> ParseFlags(this GameControllerButtons buttons)
    {
        List<GameControllerButtons> outputButtons = new List<GameControllerButtons>();
        
        foreach (GameControllerButtons button in _buttonsEnum)
        {
            if ((buttons & button) != 0)
                outputButtons.Add(button);
        }

        return outputButtons;
    }
}