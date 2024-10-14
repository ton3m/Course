using System.Collections.Generic;
using UnityEngine;

public interface IPatrolPointsProvider
{
    IEnumerable<Vector3> PatrolPoints { get; }
}