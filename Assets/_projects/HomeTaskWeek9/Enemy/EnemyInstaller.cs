using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyInstaller : MonoBehaviour,
IPositionProvider, IPatrolPointsProvider, IUpdaterProvider, IMoveDirectionInputProvider, ITargetProvider
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _trackTargetZoneRadius;

    private CircularZone _zone;
    private TargetInZoneTracker _tracker;
    private EnemyStateMachine _stateMachine;

    public void Init(ReactionBehaviour reactionBehaviour, RegularBehaviour regularBehaviour)
    {
        PatrolPoints = GetPatrolPoints();
        Input = new MoveDirectionInput();
        Updater = new Updater();

        Mover mover = new(_rigidbody, 5);
        Rotater rotater = new(transform, 360);

        Action updateRotation = () => rotater.RotateByStepTo(MoveDirection);
        Action updateMovement = () => mover.MoveByStepIn(MoveDirection);

        _stateMachine = InitStateMachine(reactionBehaviour, regularBehaviour);
        _tracker = InitTracker();

        SubForUpdate(updateRotation, updateMovement, _tracker.Update);
    }

    private EnemyStateMachine InitStateMachine(ReactionBehaviour reaction, RegularBehaviour regular)
    {
        BehavioursHandler handler = new(gameObject);

        IState reactionState = handler.HandleReactionBehaviour(reaction);
        IState regularState = handler.HandleRegularBehaviour(regular);

        return new EnemyStateMachine(regularState, reactionState);
    }

    private TargetInZoneTracker InitTracker()
    {
        IZone zone = new CircularZone(() => Position, 8);

        return new TargetInZoneTracker(_zone, this);
    }

    public Vector3 MoveDirection => Input.Direction;
    public Vector3 Position => _rigidbody.position;
    public Transform Target => FindObjectOfType<CharacterInstaller>().transform;

    public IEnumerable<Vector3> PatrolPoints { get; private set; }
    public IMoveDirectionInput Input { get; private set; }
    public IUpdater Updater { get; private set; }

    private void SubForUpdate(params Action[] actions)
    {
        actions.ToList().ForEach(action =>
            Updater.GetNewProcess(new ActionUpdatableWrap(action))
                .Enable());
    }

    private void OnEnable()
    {
        _tracker.TargetEntered += _stateMachine.EnterTargerReaction;
        _tracker.TargetLeft += _stateMachine.EnterRegular;
    }

    private void OnDisable()
    {
        _tracker.TargetEntered -= _stateMachine.EnterTargerReaction;
        _tracker.TargetLeft -= _stateMachine.EnterRegular;
    }

    private void Start() => _stateMachine.EnterRegular();

    private void Update() => Updater.UpdateAll();

    private static List<Vector3> GetPatrolPoints()
    {
        return new()
        {
            Vector3.right * 5,
            Vector3.right * -5,
            Vector3.forward * 5,
            Vector3.forward * -5
        };
    }
}
