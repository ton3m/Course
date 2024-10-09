namespace ItemsGame
{
    public class Health : IHealth, IValueIncreasable
    {
        private readonly float _maxValue;

        public Health(float maxValue, float value)
        {
            _maxValue = maxValue;
            Value = value;

            if (Value > _maxValue) Value = _maxValue;
        }

        public float Value { get; private set; }

        public void Increase(float value) => Value += value;
    }
}