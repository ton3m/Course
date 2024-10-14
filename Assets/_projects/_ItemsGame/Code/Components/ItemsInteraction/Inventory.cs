using UnityEngine;

namespace ItemsGame.ItemsHandlers
{
    public class Inventory : IInventory
    {
        private IItem _item;
     
        private readonly IItemUser _itemUser;
        private readonly IInventoryView _view;

        public Inventory(IItemUser itemUser, IInventoryView view)
        {
            _view = view;
            _itemUser = itemUser;
        }

        public bool HasItem => _item is not null;

        public Result CanAddItem(IItem item)
        {
            if (HasItem)
                return Result.Failed("Inventory is full!");

            if (_itemUser.CanUse(item) == false)
                return Result.Failed($"Item {item.Name} is not available.");

            return Result.Success;
        }

        public void AddItem(IItem item)
        {
            var result = CanAddItem(item);

            if (result.IsSuccess == false)
            {
                Debug.LogError(result.Message);
                return;
            }

            _item = item;
            
            _view.Clear();
            _view.Add(_item.View);
        }

        public IItem GetItem() => _item;

        public void Clear()
        {
            _item = null;
            _view.Clear();
        }
    }
}