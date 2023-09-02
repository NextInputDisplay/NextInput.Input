namespace NextInput.Input;

public static class GameControllerButtonsExtensions
{
    private static GameControllerButtons[] _buttonsEnum = Enum.GetValues<GameControllerButtons>();
    
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