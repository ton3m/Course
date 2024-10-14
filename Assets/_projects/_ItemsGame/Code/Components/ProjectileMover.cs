using UnityEngine;

namespace ItemsGame
{
    public class ProjectileMover : MonoBehaviour
    {
        [SerializeField] private float _speed = 3;
        [SerializeField] private float _gravity = -10;

        private BallisticCalculator _calculator;

        private bool _isMoving;
        private float _elapsedTime;

        private void Awake() => 
            _calculator = new BallisticCalculator(_speed, _gravity);

        private void Update()
        {
            if (_isMoving)
            {
                ProcessProgress();
                Move(Progress);
            }
        }

        private float Progress => _calculator.Time2Progress(_elapsedTime);

        public void LaunchAt(Vector3 target)
        {
            if (_isMoving) return;

            _calculator.SetPoints(transform.position, target);

            StartMove();
        }

        private void Move(float progress)
        {
            _calculator.SetSpeed(_speed);
            _calculator.SetGravity(_gravity);

            transform.position = _calculator.GetPoint(progress);
        }

        private void ProcessProgress()
        {
            _elapsedTime += Time.deltaTime;

            if (Progress > 1)
            {
                StopMove();
                Destroy(gameObject);
            }
        }

        private void StartMove()
        {
            _isMoving = true;
            _elapsedTime = 0;
        }

        private void StopMove()
        {
            _isMoving = false;
        }
    }
}