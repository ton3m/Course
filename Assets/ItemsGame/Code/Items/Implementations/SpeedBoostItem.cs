using UnityEngine;

namespace ItemsGame.Code.New
{
    public class SpeedBoostItem : SingleEffectItem
    {
        [SerializeField] private float _boostValue = 10;

        protected override IEffect Effect => new IncreaseSpeedEffect(_boostValue);
    }
}