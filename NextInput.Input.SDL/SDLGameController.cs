using static SDL2.SDL;

namespace NextInput.Input.SDL;

public class SDLGameController : IGameController
{
    internal IntPtr GameControllerPtr;
    private List<GameControllerButtons> _supportedButtonsCache;
    private List<GameControllerAxes> _supportedAxesCache;
    
    internal SDLGameController(int gameControllerIndex, GameControllerDeviceInformation deviceInformation)
    {
        DeviceInformation = deviceInformation;

        GameControllerPtr = SDL_GameControllerOpen(gameControllerIndex);

        _supportedButtonsCache = DeviceInformation.SupportedButtons.GetAllFlags();
        _supportedAxesCache = DeviceInformation.SupportedAxes.GetAllFlags();
    }
    
    public GameControllerDeviceInformation DeviceInformation { get; }
    public bool IsConnected => SDL_GameControllerGetAttached(GameControllerPtr) == SDL_bool.SDL_TRUE;

    public bool GetButton(GameControllerButtons button) =>
        SDL_GameControllerGetButton(GameControllerPtr, button.ToSDLGameControllerButton()) == 1;

    public GameControllerButtons GetAllHeldButtons()
    {
        GameControllerButtons heldButtons = GameControllerButtons.None;
        
        foreach (GameControllerButtons button in _supportedButtonsCache)
            if (GetButton(button))
                heldButtons |= button;

        return heldButtons;
    }

    public List<(GameControllerButtons Button, bool IsHeld)> GetAllButtons()
    {
        List<(GameControllerButtons Button, bool IsHeld)> buttons = new();

        foreach (GameControllerButtons button in _supportedButtonsCache)
            buttons.Add((button, GetButton(button)));

        return buttons;
    }


    public GameControllerButtons GetHeldButtons(GameControllerButtons flags)
    {
        GameControllerButtons heldButtons = GameControllerButtons.None;

        foreach (GameControllerButtons button in _supportedButtonsCache)
            if (flags.HasFlag(button) && GetButton(button))
                heldButtons |= button;

        return heldButtons;
    }

    public List<(GameControllerButtons Button, bool IsHeld)> GetButtons(GameControllerButtons flags)
    {
        List<(GameControllerButtons Button, bool IsHeld)> buttons = new();

        foreach (GameControllerButtons button in _supportedButtonsCache)
            if (flags.HasFlag(button))
                buttons.Add((button, GetButton(button)));

        return buttons;
    }

    public float GetAxis(GameControllerAxes axis)
    {
        if (axis is GameControllerAxes.TriggerLeft or GameControllerAxes.TriggerRight)
            return Convert.ToAxis(SDL_GameControllerGetAxis(GameControllerPtr, axis.ToSDLGameControllerAxis()), 0, short.MaxValue);
        
        return Convert.ToAxis(SDL_GameControllerGetAxis(GameControllerPtr, axis.ToSDLGameControllerAxis()));
    }

    public List<(GameControllerAxes Axis, float Value)> GetAllAxes()
    {
        List<(GameControllerAxes Axis, float Value)> axes = new();

        foreach (GameControllerAxes axis in _supportedAxesCache)
            axes.Add((axis, GetAxis(axis)));

        return axes;
    }

    public List<(GameControllerAxes Axis, float Value)> GetAxes(GameControllerAxes flags)
    {
        List<(GameControllerAxes Axis, float Value)> axes = new();

        foreach (GameControllerAxes axis in _supportedAxesCache)
            if (flags.HasFlag(axis))
                axes.Add((axis, GetAxis(axis)));

        return axes;
    }
}