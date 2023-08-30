using System.Diagnostics;
using NextInput.Input.SDL;
using NextInput.Input.SFML;

namespace NextInput.Input.Testing;

internal class Program
{
    public static void Main(string[] args)
    {
        InputBackendManager.RegisterInputBackend<SFMLInputBackend>();
        InputBackendManager.RegisterInputBackend<SDLInputBackend>();
        
        IInputBackend backend = InputBackendManager.GetInputBackend();

        Stopwatch sw = new Stopwatch();

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

        while (true)
        {
            Console.Clear();
            backend.UpdateJoysticks();
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
        }
        
    }
}