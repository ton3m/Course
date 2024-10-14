using System;
using UnityEngine;

public class BehavioursHandler
{
    private readonly GameObject _user;
    private readonly MoveBehaviourHandler moveBehaviourHandler;

    public BehavioursHandler(GameObject user)
    {
        _user = user;

        IUpdater updater = user.GetComponent<IUpdaterProvider>().Updater;
        IMoveDirectionInput input = user.GetComponent<IMoveDirectionInputProvider>().Input;

        moveBehaviourHandler = new MoveBehaviourHandler(updater, input);
    }

    public IState HandleReactionBehaviour(ReactionBehaviour behaviour)
    {
        return behaviour switch
        {
            ReactionBehaviour.RunAway => GetMoveAwayState(),
            ReactionBehaviour.Chase => GetChaseState(),
            ReactionBehaviour.DieInFear => GetDieInFearState(),
            _ => GetIdleState()
        };
    }

    public IState HandleRegularBehaviour(RegularBehaviour behaviour)
    {
        return behaviour switch
        {
            RegularBehaviour.Stay => GetIdleState(),
            RegularBehaviour.Patrol => GetPatrolState(),
            RegularBehaviour.RandomWalking => GetRandomMoveState(),
            _ => GetIdleState()
        };
    }

    private IState GetChaseState()
    {
        var positionProvider = _user.GetComponent<IPositionProvider>();
        var targetProvider = _user.GetComponent<ITargetProvider>();

        Func<Vector3?> getTargetPosition = () => targetProvider.Target?.position ?? null;

        var behaviour = new ChaseBehaviour(() => positionProvider.Position, getTargetPosition);

        IProcess process = moveBehaviourHandler.GetHandled(behaviour);

        return ActionState.NewFrom(process);
    }

    private IState GetMoveAwayState()
    {
        var positionProvider = _user.GetComponent<IPositionProvider>();
        var targetProvider = _user.GetComponent<ITargetProvider>();

        Func<Vector3?> getTargetPosition = () => targetProvider.Target?.position ?? null;

        var behaviour = new MoveAwayBehavior(() => positionProvider.Position, getTargetPosition);

        IProcess process = moveBehaviourHandler.GetHandled(behaviour);
        //IProcess testProcess = new ActionProcess(() => Debug.Log("Enabled"), () => Debug.Log("Disabled"));
        //process = new CombinedProcess(process, testProcess);
        
        return ActionState.NewFrom(process);
    }

    private IState GetRandomMoveState()
    {
        var behaviour = new RandomMoveBehaviour(1);

        IProcess process = moveBehaviourHandler.GetHandled(behaviour);

        return ActionState.NewFrom(process);
    }

    private IState GetPatrolState()
    {
        var positionProvider = _user.GetComponent<IPositionProvider>();
        var pointsProvider = _user.GetComponent<IPatrolPointsProvider>();

        var behaviour = new PatrolBehaviour(() => positionProvider.Position, pointsProvider.PatrolPoints);

        IProcess process = moveBehaviourHandler.GetHandled(behaviour);

        return ActionState.NewFrom(process);
    }

    private IState GetDieInFearState()
    {
        var behaviour = new DieBehaviour(_user);

        return new ActionState(behaviour.Die);
    }

    private IState GetIdleState() => new ActionState(() => Debug.Log("Entered Idle state"));
}
