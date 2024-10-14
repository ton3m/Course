using UnityEngine;

public class RotaterMb : MonoBehaviour
{
    public Vector3 Direction {get; private set;}

    private void Update()
    {
        if (Direction.magnitude > 0)
            ByStepRotateTo(Direction);
    }

    public void RotateTo(Vector3 direction)
    {
        Direction = Vector3.Normalize(direction);
    }

    private void ByStepRotateTo(Vector3 direction)
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