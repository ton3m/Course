namespace ItemsGame
{
    public class IncreaseHealthEffect : IEffect
    {
        private readonly float _value;

        public IncreaseHealthEffect(float value)
        {
            _value = value;
        }

        public void ApplyFor(DependenciesHolder holder)
        {
            holder.Container.GetComponent<IHealthIncreaser>().IncreaseHealth(_value);
        }

        public bool CanApplyFor(DependenciesHolder holder) =>
            holder.Container.TryGetComponent<IHealthIncreaser>(out _);
    }
}