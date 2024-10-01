using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vector3 _direction;

    private void Update()
    {
        transform.position += _direction.normalized * (_speed * Time.deltaTime);
    }

    public void Launch(Vector3 direction) => _direction = direction;
}