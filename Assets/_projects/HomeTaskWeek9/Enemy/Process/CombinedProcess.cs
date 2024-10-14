using System.Collections.Generic;

public class CombinedProcess : IProcess
{
    private readonly List<IProcess> _processes;

    public CombinedProcess(params IProcess[] processes)
    {
        _processes = new List<IProcess>(processes);
    }

    public void Disable() => _processes.ForEach(process => process?.Disable());

    public void Enable() => _processes.ForEach(process => process?.Enable());
}
