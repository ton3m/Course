namespace ItemsGame
{
    public class IncreaseSpeedEffect : IEffect
    {
        private readonly float _value;

        public IncreaseSpeedEffect(float value)
        {
            _value = value;
        }

        public void ApplyFor(DependenciesHolder holder)
        {
            holder.Container.GetComponent<ISpeedIncreaser>().IncreaseSpeed(_value);
        }

        public bool CanApplyFor(DependenciesHolder holder) =>
            holder.Container.TryGetComponent<ISpeedIncreaser>(out _);
    }
}