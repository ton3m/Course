using UnityEngine;

namespace ItemsGame.Code.New
{
    public class HealItem : SingleEffectItem
    {
        [SerializeField] private float _healValue = 10;
                                                             
        protected override IEffect Effect => new IncreaseHealthEffect(_healValue);
    }
}