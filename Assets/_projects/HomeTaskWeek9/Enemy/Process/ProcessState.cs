public class ProcessState : IState
{
    private readonly IProcess _process;

    public ProcessState(IProcess process)
    {
        _process = process;
    }

    public void Enter() => _process.Enable();

    public void Exit() => _process.Disable();
}
