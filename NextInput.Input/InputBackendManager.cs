namespace NextInput.Input;

public static class InputBackendManager
{
    private static List<(string backendName, Func<object> creationFunction)> _registeredInputBackends = new();

    public static bool RegisterInputBackend<TInputBackend>()
        where TInputBackend : IInputBackend
    {
        foreach ((string backendName, Func<object> creationFunction) in _registeredInputBackends)
            if (backendName == TInputBackend.InputBackendName)
                return false;

        _registeredInputBackends.Add((TInputBackend.InputBackendName, TInputBackend.CreateInputBackend));
        return true;
    }
    
    public static IInputBackend GetInputBackend(string? desiredBackend = null)
    {
        if (desiredBackend is null)
            return (IInputBackend)_registeredInputBackends.First().creationFunction();

        return (IInputBackend)_registeredInputBackends.First(x => x.backendName == desiredBackend).creationFunction();
    }
}