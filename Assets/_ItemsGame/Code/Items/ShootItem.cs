using UnityEngine;

namespace ItemsGame
{
    public class ShootItem : ItemHolder
    {
        [SerializeField] private ProjectileMover projectileMover;
        [SerializeField] private ParticleSystem _afterUseParticles;

        protected override IItem GetItemBase()
        {
            var item = new EffectHoldingItem(nameof(ShootItem), new ShootEffect(projectileMover));
            
            item.SetAfterUseEffect(new SpawnParticlesEffect(_afterUseParticles));
            
            return item;
        }
    }
}