namespace NextInput.Input;

/// <summary>
/// Static class providing helpers to work with <see cref="GameControllerAxes"/>
/// </summary>
public static class GameControllerAxesExtensions
{
    private static GameControllerAxes[] _axesEnum = Enum.GetValues<GameControllerAxes>();
    
    /// <summary>
    /// Get the possible multiple axes that <paramref name="axes"/> contains
    /// <param name="axes">A <see cref="GameControllerAxes"/> that holds 1 or more axes</param>
    /// <returns>A collection of the <see cref="GameControllerAxes"/> retrieved from <paramref name="axes"/></returns>
    /// </summary>
    public static List<GameControllerAxes> GetAllFlags(this GameControllerAxes axes)
    {
        List<GameControllerAxes> outputAxes = new List<GameControllerAxes>();
        
        foreach (GameControllerAxes axis in _axesEnum)
        {
            if ((axes & axis) != 0)
                outputAxes.Add(axis);
        }

        return outputAxes;
    }
    
    /// <summary>
    /// Get the possible multiple axes that <paramref name="axes"/> contains that are also in <paramref name="flags"/>
    /// <param name="axes">A <see cref="GameControllerAxes"/> that holds 1 or more axes</param>
    /// <param name="flags">Restrict the results to only these axes</param>
    /// <returns>A collection of the <see cref="GameControllerAxes"/> retrieved from <paramref name="axes"/> restricted by <paramref name="flags"/></returns>
    /// </summary>
    public static List<GameControllerAxes> GetFlags(this GameControllerAxes axes, GameControllerAxes flags)
    {
        List<GameControllerAxes> outputAxes = new List<GameControllerAxes>();
        
        foreach (GameControllerAxes axis in _axesEnum)
        {
            if ((flags & axis) != 0 && (axes & axis) != 0)
                outputAxes.Add(axis);
        }

        return outputAxes;
    }
}