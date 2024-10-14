using UnityEngine;

public class Rotater
{
    private readonly Transform _transform;
    private readonly float _rotationSpeed;

    public Rotater(Transform transform, float rotationSpeed = 360f)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
    }

    public void RotateByStepTo(Vector3 direction)
    {
        if (direction.magnitude > 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            float step = _rotationSpeed * Time.deltaTime;

            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
        }
    }

    public void RotateTo(Vector3 direction)
    {
        if (direction.magnitude > 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            float step = 360;

            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
        }
    }
}
