public class MoveBehaviourHandler
{
    private readonly IUpdater _updater;
    private readonly IMoveDirectionInput _input;

    public MoveBehaviourHandler(IUpdater updater, IMoveDirectionInput input)
    {
        _updater = updater;
        _input = input;
    }

    public IProcess GetHandled(IMoveBehaviour moveBehaviour)
    {
        IProcess update = _updater.GetNewProcess(moveBehaviour);
        IProcess writeInput = _input.ReadFrom(moveBehaviour);

        return new CombinedProcess(update, writeInput);
    }
}
