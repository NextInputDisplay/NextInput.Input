namespace NextInput.Input;

/// <summary>
/// Static class to interact with <see cref="IInputBackend"/>s
/// </summary>
public static class InputBackendManager
{
    private static List<(string backendName, Func<object> creationFunction)> _registeredInputBackends = new();

    /// <summary>
    /// Registers a <see cref="IInputBackend"/> in the list of available backends
    /// </summary>
    /// <typeparam name="TInputBackend">The type of the <see cref="IInputBackend"/> implementation</typeparam>
    /// <returns>True if the backend was added to the list of backends<br/>False if the backend is already present in the list of backend</returns>
    public static bool RegisterInputBackend<TInputBackend>()
        where TInputBackend : IInputBackend
    {
        foreach ((string backendName, Func<object> creationFunction) in _registeredInputBackends)
            if (backendName == TInputBackend.InputBackendName)
                return false;

        _registeredInputBackends.Add((TInputBackend.InputBackendName, TInputBackend.CreateInputBackend));
        return true;
    }
    
    /// <summary>
    /// Get a <see cref="IInputBackend"/> instance off of the already registered backends
    /// </summary>
    /// <param name="desiredBackend">Optional identifier of the desired <see cref="IInputBackend"/></param>
    /// <returns>An instance of the <see cref="IInputBackend"/> implementation</returns>
    public static IInputBackend GetInputBackend(string? desiredBackend = null)
    {
        if (desiredBackend is null)
            return (IInputBackend)_registeredInputBackends.First().creationFunction();

        return (IInputBackend)_registeredInputBackends.First(x => x.backendName == desiredBackend).creationFunction();
    }
}