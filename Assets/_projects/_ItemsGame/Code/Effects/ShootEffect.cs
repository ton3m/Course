using UnityEngine;

namespace ItemsGame
{
    public class ShootEffect : IEffect
    {
        private readonly ProjectileMover _projectileMover;

        public ShootEffect(ProjectileMover projectileMover)
        {
            _projectileMover = projectileMover;
        }

        public void ApplyFor(DependenciesHolder holder)
        {
            Transform shootPoint = holder.Container.GetComponent<ShootPointHolder>().ShootPoint.transform;

            ProjectileMover projectileMover =
                Object.Instantiate(_projectileMover, shootPoint.position, Quaternion.identity);

            Vector3 targetPoint = GetTargetPoint();

            projectileMover.LaunchAt(targetPoint);
        }

        private static Vector3 GetTargetPoint()
        {
            Witch witch = Object.FindObjectOfType<Witch>();

            Vector3 targetPoint = witch is null ?
                Vector3.up * 20 :
                witch.transform.position + Vector3.up * 1.5f;
            
            return targetPoint;
        }

        public bool CanApplyFor(DependenciesHolder holder) =>
            holder.Container.TryGetComponent<ShootPointHolder>(out _);
    }
}