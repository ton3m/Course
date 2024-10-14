using System;
using UnityEngine;

public class CircularZone : IZone
{
    private readonly Func<Vector3> _getOwnerPosition;
    private readonly float _radius;

    public CircularZone(Func<Vector3> getOwnerPosition, float radius)
    {
        _getOwnerPosition = getOwnerPosition;
        _radius = radius;
    }
    
    public bool IsPointInside(Vector3 point)
    {
        float distance = (point - _getOwnerPosition()).magnitude;

        return distance < _radius;
    }
}
