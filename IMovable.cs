using UnityEngine;

public interface IMovable
{
    Vector3 Position { get; }

    void MoveIn(Vector3 direction);
}