using NextInput.Input.SDL;
using NextInput.Input.SFML;

namespace NextInput.Input.Testing;

public class GameControllers
{
    public static void Run(string[] args)
    {
        InputBackendManager.RegisterInputBackend<SDLInputBackend>();
        
        IInputBackend backend = InputBackendManager.GetInputBackend();

        //Stopwatch sw = new Stopwatch();

        List<IGameController> gameControllers = new List<IGameController>();
        
        backend.UpdateGameControllers();

        foreach (GameControllerDeviceInformation info in backend.GameControllers)
        {
            Console.WriteLine(info.DeviceName);
            Console.WriteLine(info.DeviceType);
            
            Console.WriteLine("Supported buttons");
            foreach (GameControllerButtons supportedButton in info.SupportedButtons.ParseFlags())
                Console.WriteLine(supportedButton);

            Console.WriteLine();
            Console.WriteLine("Supported axes");
            foreach (GameControllerAxes supportedAxis in info.SupportedAxes.ParseFlags())
                Console.WriteLine(supportedAxis);
            
            gameControllers.Add(backend.GetGameController(info));
        }
    }
}