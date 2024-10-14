using System;
using UnityEngine;

public class ChaseBehaviour : IMoveBehaviour
{
    private readonly Func<Vector3> _getUserPosition;
    private readonly Func<Vector3?> getTargetPosition;

    public Vector3 Direction { get; private set; }

    public ChaseBehaviour(Func<Vector3> getUserPosition, Func<Vector3?> getTargetPosition)
    {
        _getUserPosition = getUserPosition;
        this.getTargetPosition = getTargetPosition;
    }

    public void Update()
    {
        Vector3? position = getTargetPosition();
        
        if (position is null) return;
        
        Chase(position.Value);
    }

    private void Chase(Vector3 targetPoint)
    {
        Direction = (targetPoint - _getUserPosition()).normalized;
    }
}
