using System;
using UnityEngine;

public class MoveAwayBehavior : IMoveBehaviour
{
    private readonly Func<Vector3> _getUserPosition;
    private readonly Func<Vector3?> _getTargetPosition;

    public Vector3 Direction { get; private set; }

    public MoveAwayBehavior(Func<Vector3> getUserPosition, Func<Vector3?> getTargetPosition)
    {
        _getUserPosition = getUserPosition;
        _getTargetPosition = getTargetPosition;
    }

    public void Update()
    {
        Vector3? position = _getTargetPosition();
        
        if (position is null) return;
        
        MoveAway(position.Value);
    }

    private void MoveAway(Vector3 point)
    {
        Direction = -(point - _getUserPosition()).normalized;
    }
}
