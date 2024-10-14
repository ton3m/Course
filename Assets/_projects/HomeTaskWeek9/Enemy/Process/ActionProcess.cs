using System;

public class ActionProcess : IProcess
{
    private readonly Action _enableAction;
    private readonly Action _disableAction;

    public ActionProcess(Action enable, Action disable)
    {
        _enableAction = enable;
        _disableAction = disable;
    }

    public void Enable() => _enableAction?.Invoke();

    public void Disable() => _disableAction?.Invoke();
}
