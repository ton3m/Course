using UnityEngine;

namespace ItemsGame
{
    public class SpeedBoostItem : ItemHolder
    {
        [SerializeField] private float _boostValue = 10;
        [SerializeField] private ParticleSystem _afterUseParticles;
        
        protected override IItem GetItemBase()
        {
            var item = new EffectHoldingItem(nameof(SpeedBoostItem), new IncreaseSpeedEffect(_boostValue));
            
            item.SetAfterUseEffect(new SpawnParticlesEffect(_afterUseParticles));
            
            return item;
        }
    }
}