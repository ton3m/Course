using System.Collections.Generic;

namespace ItemsGame.Code.New
{
    public abstract class SingleEffectItem : EffectsItem
    {
        protected abstract IEffect Effect { get; }
        protected override List<IEffect> Effects => new() { Effect };
    }
}