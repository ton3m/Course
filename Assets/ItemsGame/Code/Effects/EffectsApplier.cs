using System.Collections.Generic;

namespace ItemsGame.Code.New
{
    public class EffectsApplier : IEffectsApplier
    {
        private readonly DependenciesContainer _container;

        public EffectsApplier(DependenciesContainer container)
        {
            _container = container;
        }

        public bool CanApply(IEffect effect) => effect.CanInitFrom(_container);

        public void Apply(IEffect effect)
        {
            effect.InitFrom(_container);
            effect.Apply();
        }

        public void Apply(List<IEffect> effects) => effects.ForEach(Apply);

        public bool CanApply(List<IEffect> effects)
        {
            foreach (var effect in effects)
                if (effect.CanInitFrom(_container) == false) 
                    return false;

            return true;
        }
    }

    public interface IEffectApplierHolder
    {
        IEffectsApplier EffectsApplier { get; }    
    }
    
    public interface IEffectsApplier
    {
        bool CanApply(IEffect effect);
        void Apply(IEffect effect);
        
        bool CanApply(List<IEffect> effects);
        void Apply(List<IEffect> effects);
    }
}