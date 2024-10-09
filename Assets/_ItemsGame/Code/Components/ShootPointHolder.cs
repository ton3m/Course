using UnityEngine;

namespace ItemsGame
{
    public class ShootPointHolder : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;

        public Transform ShootPoint => _shootPoint;
    }
}