namespace ItemsGame
{
    public interface IInventory
    {
        IItem GetItem();
        Result CanAddItem(IItem item);
        void AddItem(IItem item);
        void Clear();
    }
}