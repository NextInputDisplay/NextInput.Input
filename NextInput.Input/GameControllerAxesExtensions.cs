namespace NextInput.Input;

public static class GameControllerAxesExtensions
{
    private static GameControllerAxes[] _axesEnum = Enum.GetValues<GameControllerAxes>();
    
    public static List<GameControllerAxes> ParseFlags(this GameControllerAxes axes)
    {
        List<GameControllerAxes> outputAxes = new List<GameControllerAxes>();
        
        foreach (GameControllerAxes axis in _axesEnum)
        {
            if ((axes & axis) != 0)
                outputAxes.Add(axis);
        }

        return outputAxes;
    }
}