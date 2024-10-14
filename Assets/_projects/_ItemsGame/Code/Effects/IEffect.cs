namespace ItemsGame
{
    public interface IEffect 
    {
        public void ApplyFor(DependenciesHolder holder);
        public bool CanApplyFor(DependenciesHolder holder);
    }
}