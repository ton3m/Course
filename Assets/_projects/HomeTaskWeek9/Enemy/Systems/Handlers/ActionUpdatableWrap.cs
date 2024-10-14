using System;

public class ActionUpdatableWrap : IUpdatableBehaviour
{
    private readonly Action _action;

    public ActionUpdatableWrap(Action action)
    {
        _action = action;
    }

    public void Update() => _action?.Invoke();
}
