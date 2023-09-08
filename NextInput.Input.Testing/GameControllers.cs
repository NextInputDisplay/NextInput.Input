using NextInput.Input.SDL;

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
            foreach (GameControllerButtons supportedButton in info.SupportedButtons.GetAllFlags())
                Console.WriteLine(supportedButton);

            Console.WriteLine();
            Console.WriteLine("Supported buttons (dpad + misc only)");
            foreach (GameControllerButtons supportedButton in info.SupportedButtons.GetFlags(
                         GameControllerButtons.DPadDown | GameControllerButtons.DPadLeft |
                         GameControllerButtons.DPadRight | GameControllerButtons.DPadUp | GameControllerButtons.MiscellaneousOne))
                Console.WriteLine(supportedButton);
            
            Console.WriteLine();
            Console.WriteLine("Supported axes");
            foreach (GameControllerAxes supportedAxis in info.SupportedAxes.GetAllFlags())
                Console.WriteLine(supportedAxis);
            
            Console.WriteLine();
            Console.WriteLine("Supported axes (triggers only)");
            foreach (GameControllerAxes supportedAxis in info.SupportedAxes.GetFlags(
                         GameControllerAxes.TriggerLeft | GameControllerAxes.TriggerRight))
                Console.WriteLine(supportedAxis);
            
            gameControllers.Add(backend.GetGameController(info));
        }
        
        Thread.Sleep(2000);

        int refreshCount = 0;
        
        while (true)
        {
            Console.Clear();
            backend.UpdateGameControllers();
            
            Console.WriteLine(refreshCount);
            if (!gameControllers[0].IsConnected)
                break;

            foreach ((GameControllerButtons button, bool isHeld) in gameControllers[0].GetAllButtons())
            {
                Console.WriteLine($"{button}: {isHeld}");
            }
            
            foreach ((GameControllerAxes axis, float value) in gameControllers[0].GetAllAxes())
            {
                Console.WriteLine($"{axis}: {value}");
            }
            
            Thread.Sleep(33);
            refreshCount++;
        }

        backend.DisposeGameController(gameControllers[0]);
        Console.WriteLine("Controller was disconnected");
        
        // 5 seconds to test and reconnect your game controller to see if it is still picked up
        Thread.Sleep(5000);
        
        backend.UpdateGameControllers();
        foreach (GameControllerDeviceInformation gameControllerDeviceInformation in backend.GameControllers)
        {
            Console.WriteLine(gameControllerDeviceInformation.DeviceName);
        }
    }
}