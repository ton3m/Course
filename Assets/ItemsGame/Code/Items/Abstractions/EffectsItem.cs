using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ItemsGame.Code.New
{
    public abstract class EffectsItem : MonoBehaviour, IItem
    {
        private IEffectsApplier _applier;
        
        protected abstract List<IEffect> Effects { get; }

        public List<string> Dependencies =>  
            new List<string> { nameof(IEffectsApplier) }
                .Concat(Effects.SelectMany(e => e.Dependencies))
                .ToList();

        public bool CanInitFrom(DependenciesContainer container) => 
            container.Holder.TryGetComponent<IEffectApplierHolder>(out _);

        public void InitFrom(DependenciesContainer container)
        {
            _applier = container.Holder.GetComponent<IEffectApplierHolder>().EffectsApplier;
        }

        public bool CanUse() => _applier.CanApply(Effects);

        public void Use() => _applier.Apply(Effects);
    }
}