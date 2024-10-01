using System.Collections.Generic;

namespace ItemsGame.Code.New
{
    public class IncreaseHealthEffect : IEffect
    {
        private readonly ValueIncreaser _valueIncreaser;

        public IncreaseHealthEffect(float value)
        {
            _valueIncreaser = new ValueIncreaser(value);
        }

        public List<string> Dependencies => new() { nameof(IHealthHolder) };

        public bool CanInitFrom(DependenciesContainer container) =>
            container.Holder.TryGetComponent<IHealthHolder>(out _);

        public void InitFrom(DependenciesContainer container)
        {
            IValueIncreasable value = container.Holder.GetComponent<IHealthHolder>().Health;
            _valueIncreaser.Init(value);
        }

        public void Apply() => _valueIncreaser.Increase();
    }
}