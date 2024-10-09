using UnityEngine;

namespace ItemsGame
{
    public class HealItem : ItemHolder
    {
        [SerializeField] private float _healValue = 10;
        [SerializeField] private ParticleSystem _afterUseParticles;

        protected override IItem GetItemBase()
        {
            var item = new EffectHoldingItem(nameof(HealItem), new IncreaseHealthEffect(_healValue));
            
            item.SetAfterUseEffect(new SpawnParticlesEffect(_afterUseParticles));
            
            return item;
        }
    }
}