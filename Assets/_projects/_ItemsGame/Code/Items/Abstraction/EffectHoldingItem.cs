using System.Collections.Generic;
using UnityEngine;

namespace ItemsGame
{
    public class EffectHoldingItem : IItem
    {
        private readonly List<IEffect> _effects;

        public EffectHoldingItem(string itemName, List<IEffect> effects)
        {
            _effects = effects;
            Name = itemName;
        }

        public EffectHoldingItem(string itemName, IEffect effect) :
            this(itemName, new List<IEffect> { effect })
        {
        }

        public GameObject View { get; private set; }

        public string Name { get; }

        public void SetAfterUseEffect(IEffect effect) => _effects.Add(effect);

        public void SetView(GameObject view)
        {
            if (view == null)
            {
                Debug.LogError("Cant set NULL view!");
                return;
            }

            View = view;
        }

        public void Use(DependenciesHolder holder)
        {
            foreach (var effect in _effects)
            {
                effect.ApplyFor(holder);
            }
        }

        public bool CanUse(DependenciesHolder holder)
        {
            foreach (var effect in _effects)
                if (effect.CanApplyFor(holder) == false)
                    return false;

            return true;
        }
    }
}