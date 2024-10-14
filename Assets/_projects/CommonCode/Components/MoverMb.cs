using ItemsGame;
using UnityEngine;

public class MoverMb : MonoBehaviour, ItemsGame.IMover, IValueIncreasable
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidBody;

    public float Speed => _speed;
    public Vector3 Position => transform.position;
    public Vector3 Direction { get; private set; }

    private void Update()
    {
        _rigidBody.velocity = Direction * _speed;
    }

    public void Move(Vector3 direction) => Direction = direction.normalized;

    public void Increase(float value) => _speed += value;
}
