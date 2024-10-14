public class EnemyStateMachine
{
    private readonly IState _regular;
    private readonly IState _targerReaction;
    private IState _current;

    public EnemyStateMachine(IState regular, IState targetReaction)
    {
        _regular = regular;
        _targerReaction = targetReaction;
    }

    public void EnterTargerReaction() => SetState(_targerReaction);
    public void EnterRegular() => SetState(_regular);

    private void SetState(IState state)
    {
        _current?.Exit();
        _current = state;
        _current.Enter();
    }
}
