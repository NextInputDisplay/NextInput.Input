namespace NextInput.Input;

/// <summary>
/// Base abstraction of a device information
/// </summary>
public interface IDeviceInformation
{
    /// <summary>
    /// The name of the device
    /// <remarks>A device should always have a name attached to it</remarks>
    /// </summary>
    public string DeviceName { get; }
}