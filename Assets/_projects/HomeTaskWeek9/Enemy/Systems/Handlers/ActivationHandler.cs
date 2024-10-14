using System;

public class ActivationHandler
{
    private bool _isEnabled;

    private readonly Action _onEnabled;
    private readonly Action _onDisabled;
    
    public ActivationHandler(Action onEnabled, Action onDisabled)
    {
        _onEnabled = onEnabled;
        _onDisabled = onDisabled;
    }

    public void Enable()
    {
        if (_isEnabled) return;

        _isEnabled = true;
        _onEnabled();
    }

    public void Disable()
    {
        _isEnabled = false;
        _onDisabled();
    }
}
