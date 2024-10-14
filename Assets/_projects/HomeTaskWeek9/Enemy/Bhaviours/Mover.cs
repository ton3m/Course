using UnityEngine;

public class Mover : IMover
{
    private readonly Rigidbody _rigidbody;
    private readonly float _speed;

    public Mover(Rigidbody rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        _speed = speed;
    }

    public void MoveByStepIn(Vector3 direction)
    {
        float step = _speed * Time.deltaTime;
        Vector3 point = _rigidbody.position + direction * step;

        _rigidbody.Move(point, _rigidbody.rotation);
    }
}
