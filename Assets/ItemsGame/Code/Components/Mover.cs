using ItemsGame.Code.New;
using UnityEngine;

public class Mover : MonoBehaviour, IValueIncreasable
{
    [SerializeField] private float _speed;

    private IMoverInput _input;

    public void Init(IMoverInput input)
    {
        _input = input;
    }

    private void Start()
    {
        _input ??= new PlayerInput();
    }

    private void Update()
    {
        transform.position += _input.MoveDirection * (_speed * Time.deltaTime);
    }

    public void Increase(float value) => _speed += value;
}


