namespace ItemsGame.Code.New
{
    public class Health : IValueIncreasable
    {
        private readonly float _maxValue;

        public Health(float maxValue)
        {
            _maxValue = maxValue;
            Value = maxValue;
        }
        
        public float Value { get; private set; }

        public void Increase(float value) => Value += value;
    }
    
    public interface IHealthHolder
    {
        Health Health { get; }
    }
}