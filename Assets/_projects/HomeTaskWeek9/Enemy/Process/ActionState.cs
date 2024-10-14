using System;

public class ActionState : IState
{
    private readonly Action _enterAction;
    private readonly Action _exitAction;

    public ActionState(Action enterAction, Action exitAction = null)
    {
        _enterAction = enterAction;
        _exitAction = exitAction;
    }

    public static ActionState NewFrom(IProcess process) => new(process.Enable, process.Disable);

    public void Enter() => _enterAction?.Invoke();

    public void Exit() => _exitAction?.Invoke();
}
