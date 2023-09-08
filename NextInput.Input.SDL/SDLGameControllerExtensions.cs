namespace NextInput.Input.SDL;

public static class SDLGameControllerExtensions
{
    internal static GameControllerButtons ToGameControllerButtons(this SDL2.SDL.SDL_GameControllerButton sdlButton)
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

    internal static GameControllerAxes ToGameControllerAxes(this SDL2.SDL.SDL_GameControllerAxis sdlAxis)
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

    internal static SDL2.SDL.SDL_GameControllerButton ToSDLGameControllerButton(this GameControllerButtons gameControllerButtons)
    {
        return gameControllerButtons switch
        {
            GameControllerButtons.Unknown => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_INVALID,
            GameControllerButtons.A => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_A,
            GameControllerButtons.B => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_B,
            GameControllerButtons.X => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_X,
            GameControllerButtons.Y => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_Y,
            GameControllerButtons.Back => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_BACK,
            GameControllerButtons.Guide => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_GUIDE,
            GameControllerButtons.Start => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_START,
            GameControllerButtons.LeftStick => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSTICK,
            GameControllerButtons.RightStick => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSTICK,
            GameControllerButtons.LeftShoulder => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
            GameControllerButtons.RightShoulder => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
            GameControllerButtons.DPadUp => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_UP,
            GameControllerButtons.DPadDown => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_DOWN,
            GameControllerButtons.DPadLeft => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_LEFT,
            GameControllerButtons.DPadRight => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
            GameControllerButtons.PaddleOne => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE1,
            GameControllerButtons.PaddleTwo => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE2,
            GameControllerButtons.PaddleThree => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE3,
            GameControllerButtons.PaddleFour => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE4,
            GameControllerButtons.TouchPad => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_TOUCHPAD,
            GameControllerButtons.MiscellaneousOne => SDL2.SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_MISC1,
            _ => throw new ArgumentOutOfRangeException(nameof(gameControllerButtons), gameControllerButtons, null)
        };
    }

    internal static SDL2.SDL.SDL_GameControllerAxis ToSDLGameControllerAxis(this GameControllerAxes gameControllerAxes)
    {
        return gameControllerAxes switch
        {
            GameControllerAxes.Unknown => SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_INVALID,
            GameControllerAxes.LeftX => SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTX,
            GameControllerAxes.LeftY => SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTY,
            GameControllerAxes.RightX => SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_RIGHTX,
            GameControllerAxes.RightY => SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_RIGHTY,
            GameControllerAxes.TriggerLeft => SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERLEFT,
            GameControllerAxes.TriggerRight => SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERRIGHT,
            _ => throw new ArgumentOutOfRangeException(nameof(gameControllerAxes), gameControllerAxes, null)
        };
    }
}