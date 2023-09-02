using System.Diagnostics;
using NextInput.Input.SDL;
using NextInput.Input.SFML;

namespace NextInput.Input.Testing;

public class Joysticks
{
    public static void Run(string[] args)
    {
        InputBackendManager.RegisterInputBackend<SDLInputBackend>();
        InputBackendManager.RegisterInputBackend<SFMLInputBackend>();
        
        IInputBackend backend = InputBackendManager.GetInputBackend();

        //Stopwatch sw = new Stopwatch();

        List<IJoystick> joysticks = new List<IJoystick>();
        
        backend.UpdateJoysticks();

        foreach (JoystickDeviceInformation info in backend.Joysticks)
        {
            Console.WriteLine(info.DeviceName);
            Console.WriteLine(info.DeviceAxesCount);
            Console.WriteLine(info.DeviceHatsCount);
            Console.WriteLine(info.DeviceBallsCount);
            Console.WriteLine(info.DeviceButtonsCount);
            joysticks.Add(backend.GetJoystick(info));
        }
        
        Thread.Sleep(2000);

        int refreshCount = 0;
        
        while (true)
        {
            Console.Clear();
            backend.UpdateJoysticks();
            
            Console.WriteLine(refreshCount);
            if (!joysticks[0].IsConnected)
                break;
            
            var axes = joysticks[0].GetAxes();
            for (var i = 0; i < axes.Length; i++)
                Console.WriteLine($"axis {i}: {axes[i]}");
            
            var buttons = joysticks[0].GetButtons();
            for (var i = 0; i < buttons.Length; i++)
                Console.WriteLine($"button {i}: {buttons[i]}");
            
            var hats = joysticks[0].GetHats();
            for (var i = 0; i < hats.Length; i++)
                Console.WriteLine($"hats {i}: {hats[i]}");
            
            Thread.Sleep(33);
            refreshCount++;
        }

        backend.DisposeJoystick(joysticks[0]);
        Console.WriteLine("Joystick was disconnected");
        
        // 5 seconds to test and reconnect your joystick to see if it is still picked up
        Thread.Sleep(5000);
        
        backend.UpdateJoysticks();
        foreach (JoystickDeviceInformation joystickDeviceInformation in backend.Joysticks)
        {
            Console.WriteLine(joystickDeviceInformation.DeviceName);
        }
    }
}