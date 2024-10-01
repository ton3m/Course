using System.Collections.Generic;

namespace ItemsGame.Code.New
{
    public class IncreaseSpeedEffect : IEffect
    {
        private readonly ValueIncreaser _valueIncreaser;

        public IncreaseSpeedEffect(float value)
        {
            _valueIncreaser = new ValueIncreaser(value);
        }

        public List<string> Dependencies => new() { nameof(Mover) };

        public bool CanInitFrom(DependenciesContainer container) =>
            container.Holder.TryGetComponent<Mover>(out _);

        public void InitFrom(DependenciesContainer container)
        {
            IValueIncreasable value = container.Holder.GetComponent<Mover>();
            _valueIncreaser.Init(value);
        }

        public void Apply() => _valueIncreaser.Increase();
    }
}