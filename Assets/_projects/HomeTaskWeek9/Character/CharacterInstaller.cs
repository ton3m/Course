using System;
using ItemsGame;
using UnityEngine;

public class CharacterInstaller : MonoBehaviour, IUpdaterProvider
{
    [SerializeField] private Rigidbody _rigidbody;

    public void Init(PlayerInput input)
    {
        Updater = new Updater();
        Rotater rotateBehaviour = new(_rigidbody.transform, 400);
        IMover mover = new Mover(_rigidbody, 8);

        Action move = () => mover.MoveByStepIn(input.MoveDirection);
        Action rotate = () => rotateBehaviour.RotateByStepTo(input.MoveDirection);

        IProcess moving = Updater.GetNewProcess(new ActionUpdatableWrap(move));
        IProcess rotating = Updater.GetNewProcess(new ActionUpdatableWrap(rotate));

        moving.Enable();
        rotating.Enable();
    }

    public IUpdater Updater { get; private set; }

    private void Update() => Updater.UpdateAll();
}
