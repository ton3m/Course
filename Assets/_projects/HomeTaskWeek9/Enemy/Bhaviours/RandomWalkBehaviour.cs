using System;
using UnityEngine;

public class RandomMoveBehaviour : IMoveBehaviour
{
    private float _timer;
    private Vector3? _currentDirection;

    private readonly float _changeDirectionTime;

    public RandomMoveBehaviour(float changeDirectionTime)
    {
        _changeDirectionTime = changeDirectionTime;
        _currentDirection = GetRandomDirection();
    }

    public Vector3 Direction { get; private set; }

    public void Update()
    {
        _timer += Time.deltaTime;

        if (_currentDirection is null || _timer >= _changeDirectionTime)
        {
            _currentDirection = GetRandomDirection();
            _timer = 0f;
        }

        Direction = _currentDirection.Value;
    }

    private Vector3 GetRandomDirection()
    {
        Func<float> getRandomValue = () => UnityEngine.Random.Range(-1f, 1f);

        return new Vector3(getRandomValue(), 0, getRandomValue()).normalized;
    }
}
