namespace ItemsGame
{
    public interface IItemUser
    {
        bool CanUse(IItem item);
        void Use(IItem item);
        string Name { get; }
    }
}