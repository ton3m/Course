namespace ItemsGame.Code.New
{
    public interface IItem : IDependenciesPuller
    {
        void Use();
        bool CanUse();
    }
}