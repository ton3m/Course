using UnityEngine;

namespace ItemsGame.Code.New
{
    public class ShootItem : SingleEffectItem
    {
        [SerializeField] private Projectile _projectile;
            
        protected override IEffect Effect => new ShootEffect(_projectile);
    }
}