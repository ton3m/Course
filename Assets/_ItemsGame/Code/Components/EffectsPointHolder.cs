using UnityEngine;

namespace ItemsGame
{
    public class EffectsPointHolder : MonoBehaviour
    {
        [SerializeField] private Transform _point;

        public Vector3 Point => _point.position;
    }
}