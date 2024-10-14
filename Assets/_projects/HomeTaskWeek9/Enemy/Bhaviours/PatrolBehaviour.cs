using System;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : IMoveBehaviour
{
    private Vector3? _targetPoint;

    private readonly Func<Vector3> _getUserPosition;
    private readonly Queue<Vector3> _points;

    public PatrolBehaviour(Func<Vector3> getUserPosition, IEnumerable<Vector3> points)
    {
        _getUserPosition = getUserPosition;
        _points = new Queue<Vector3>(points);
    }

    public Vector3 Direction { get; private set; }

    public void Update() => Patrol();

    private void Patrol()
    {
        Direction = Vector3.zero;
        
        if (_points.Count == 0) return;

        if (_targetPoint is null || ReachedTarget())
            _targetPoint = GetNextPoint();

        Direction = (_targetPoint.Value - _getUserPosition()).normalized;
    }

    private Vector3 GetNextPoint()
    {
        Vector3 point = _points.Dequeue();
        _points.Enqueue(point);

        return point;
    }

    private bool ReachedTarget()
    {
        float distanceToTarget = Vector3.Distance(_getUserPosition(), _targetPoint.Value);

        return distanceToTarget < 0.35f;
    }
}

public interface IDirectionProvider
{
    Vector3 Direction { get; }
}

public interface IUpdatableBehaviour
{
    void Update();
}
