using System.Collections.Generic;
using UnityEngine;

namespace ItemsGame.Code.New
{
    public class ShootEffect : IEffect
    {
        private readonly Projectile _projectile;
        private Transform _shootPoint;

        public ShootEffect(Projectile projectile)
        {
            _projectile = projectile;
        }
        
        public List<string> Dependencies => new() { nameof(ShootPoint) };

        public bool CanInitFrom(DependenciesContainer container) =>
            container.Holder.GetComponent<ShootPoint>() is not null;

        public void InitFrom(DependenciesContainer container)
        {
            _shootPoint = container.Holder.GetComponent<ShootPoint>().transform;
        }

        public void Apply()
        {
            Projectile projectile = Object.Instantiate(_projectile, _shootPoint.position, Quaternion.identity);

            projectile.Launch(_shootPoint.forward);
        }
    }
}