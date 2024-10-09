using UnityEngine;

public class Rotater : MonoBehaviour
{
    private Vector3 _direction;

    private void Update()
    {
        if (_direction.magnitude > 0)
            RotateTo(_direction);
    }

    public void SetDirection(Vector3 direction) =>
        _direction = direction;

    private void RotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        float deltaAngle = Quaternion.Angle(transform.rotation, lookRotation);
        bool angleIsLarge = deltaAngle > 100;

        float speed = 90f * 4;
        float step = speed * Time.deltaTime;
        float stepMultiplier = 2;

        if (angleIsLarge)
            step *= stepMultiplier;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }
}