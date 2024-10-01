namespace ItemsGame.Code.New
{
    public interface IEffect : IDependenciesPuller
    {
        void Apply();
    }
}