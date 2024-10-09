using UnityEngine;

namespace ItemsGame
{
    public class BallisticCalculator
    {
        private float _planeSpeed;
        private float _gravity;

        private Vector3 _startPoint;
        private Vector3 _targetPoint;

        private float _flyTime;
        private float _height;

        private Vector3 _planeDirection;

        public BallisticCalculator(float planeSpeed = 5, float gravity = -10)
        {
            SetSpeed(planeSpeed);
            SetGravity(gravity);
        }

        public float Time2Progress(float time) => Mathf.Clamp01(time / _flyTime);

        public void SetSpeed(float value)
        {
            _planeSpeed = value;
            CalculateValues();
        }

        public void SetGravity(float value)
        {
            _gravity = value;
            CalculateValues();
        }

        public void SetPoints(Vector3 start, Vector3 target)
        {
            _startPoint = start;
            _targetPoint = target;

            CalculateValues();
        }

        private void CalculateValues()
        {
            Vector3 displacement = _targetPoint - _startPoint;

            _flyTime = GetFlyTime(displacement, _planeSpeed);

            _planeDirection = displacement.normalized;
            _planeDirection.y = 0;

            _height = displacement.y;
        }

        public Vector3 GetPoint(float progress)
        {
            progress = Mathf.Clamp01(progress);

            float height = GetHeight(progress);
            float width = GetWidth(progress);

            Vector3 point = _planeDirection * width;
            point.y = height;

            return point + _startPoint;
        }

        private float GetFlyTime(Vector3 displacement, float planeSpeed)
        {
            float planeDistance = Mathf.Sqrt(
                displacement.x * displacement.x +
                displacement.z * displacement.z);

            return planeDistance / planeSpeed;
        }

        private float GetWidth(float progress) => _planeSpeed * (_flyTime * progress);

        private float GetHeight(float progress)
        {
            float a = _gravity;
            float h = _height;
            float T = _flyTime;
            float t = T * progress;

            float Vy0 = (h - (a * T * T) / 2) / T;
            float y = Vy0 * t + (a * t * t) / 2;

            return y;
        }
    }
}