namespace NextInput.Input.SDL;

public static class SDLGameControllerExtensions
{
    public static GameControllerButtons ToGameControllerButtons(this SDL2.SDL.SDL_GameControllerButton sdlButton)
    {
        return sdlButton switch
        {
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_INVALID => GameControllerButtons.Unknown,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_A => GameControllerButtons.A,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_B => GameControllerButtons.B,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_X => GameControllerButtons.X,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_Y => GameControllerButtons.Y,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_BACK => GameControllerButtons.Back,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_GUIDE => GameControllerButtons.Guide,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_START => GameControllerButtons.Start,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSTICK => GameControllerButtons.LeftStick,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSTICK => GameControllerButtons.RightStick,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSHOULDER => GameControllerButtons.LeftShoulder,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSHOULDER => GameControllerButtons.RightShoulder,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_UP => GameControllerButtons.DPadUp,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_DOWN => GameControllerButtons.DPadDown,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_LEFT => GameControllerButtons.DPadLeft,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_RIGHT => GameControllerButtons.DPadRight,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_MISC1 => GameControllerButtons.MiscellaneousOne,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE1 => GameControllerButtons.PaddleOne,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE2 => GameControllerButtons.PaddleTwo,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE3 => GameControllerButtons.PaddleThree,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE4 => GameControllerButtons.PaddleFour,
            SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_TOUCHPAD => GameControllerButtons.TouchPad,
            _ => throw new ArgumentOutOfRangeException(nameof(sdlButton), sdlButton, null)
        };
    }

    public static GameControllerAxes ToGameControllerAxes(this SDL2.SDL.SDL_GameControllerAxis sdlAxis)
    {
        return sdlAxis switch
        {
            SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_INVALID => GameControllerAxes.Unknown,
            SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTX => GameControllerAxes.LeftX,
            SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTY => GameControllerAxes.LeftY,
            SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_RIGHTX => GameControllerAxes.RightX,
            SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_RIGHTY => GameControllerAxes.RightY,
            SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERLEFT => GameControllerAxes.TriggerLeft,
            SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERRIGHT => GameControllerAxes.TriggerRight,
            _ => throw new ArgumentOutOfRangeException(nameof(sdlAxis), sdlAxis, null)
        };
    }
}