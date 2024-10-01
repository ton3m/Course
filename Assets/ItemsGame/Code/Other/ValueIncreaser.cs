namespace ItemsGame.Code.New
{
    public class ValueIncreaser
    {
        private readonly float _increaseValue;
        private IValueIncreasable _increasable;

        public ValueIncreaser(float increaseValue)
        {
            _increaseValue = increaseValue;
        }

        public void Init(IValueIncreasable increasable)
        {
            _increasable = increasable;
        }

        public void Increase() => _increasable?.Increase(_increaseValue);
    }
}