using ItemsGame;
using UnityEngine;

public class Mover : MonoBehaviour, IMover, IValueIncreasable
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidBody;

    private IMoverInput _input;
    private Vector3 _direction;
    
    public void Init(IMoverInput input)
    {
        _input = input;
    }

    public float Speed => _speed;
    
    public Vector3 Direction => _direction;
    
    private void Update()
    {
        _direction = _input.MoveDirection;
        _rigidBody.velocity = _direction * _speed;
    }

    public void Increase(float value) => _speed += value;
}