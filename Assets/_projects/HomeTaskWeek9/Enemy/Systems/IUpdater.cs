public interface IUpdater
{
    void UpdateAll();
    IProcess GetNewProcess(IUpdatableBehaviour updatable);
}
