using UnityEngine;

namespace ItemsGame
{
    public class SpawnParticlesEffect : IEffect
    {
        private ParticleSystem _particleSystem;

        public SpawnParticlesEffect(ParticleSystem particleSystem)
        {
            _particleSystem = particleSystem;
        }
        
        public void ApplyFor(DependenciesHolder holder)
        {
            Vector3 point = holder.Container.GetComponent<EffectsPointHolder>().Point;
            
            Object.Instantiate(_particleSystem, point, Quaternion.identity);
        }

        public bool CanApplyFor(DependenciesHolder holder) => 
            holder.Container.TryGetComponent<EffectsPointHolder>(out _);
    }
}