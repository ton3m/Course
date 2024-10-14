using System;
using UnityEngine;

public class TargetInZoneTracker
{
    private bool _isTargetInZone;

    private readonly IZone _zone;
    private readonly ITargetProvider _targetProvider;

    public TargetInZoneTracker(IZone zone, ITargetProvider targetProvider)
    {
        _zone = zone;
        _targetProvider = targetProvider;
    }

    public event Action TargetEntered;
    public event Action TargetLeft;

    public void Update()
    {
        Transform target = _targetProvider.Target;

        if (target == null) return;

        bool wasTargetInZone = _isTargetInZone;
        _isTargetInZone = _zone.IsPointInside(target.position);

        ProcessEvents(wasTargetInZone, _isTargetInZone);
    }

    private void ProcessEvents(bool wasTargetInZone, bool isTargetInZone)
    {
        if (wasTargetInZone == false && isTargetInZone)
        {
            TargetEntered?.Invoke();
        }
        else if (wasTargetInZone && isTargetInZone == false)
        {
            TargetLeft?.Invoke();
        }
    }
}
