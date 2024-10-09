using UnityEngine;

namespace ItemsGame
{
    public class Character
    {
        private readonly IMover _mover;
        private readonly IHealth _health;
        private readonly IInventory _inventory;
        private readonly IItemUser _itemUser;

        public Character(IMover mover, IHealth health, IInventory inventory, IItemUser itemUser)
        {
            _itemUser = itemUser;
            _mover = mover;
            _health = health;
            _inventory = inventory;
        }

        public float Health => _health.Value;
        public float Speed => _mover.Speed;
        public IItem HoldingItem => _inventory.GetItem();

        public void OnUseItemInput()
        {
            IItem item = _inventory.GetItem();

            bool canUse = item is not null;

            if (canUse)
            {
                _itemUser.Use(item);
                _inventory.Clear();
            }

            Debug.Log(canUse ? $"Item \"{item.Name}\" used!" : "Has no item to use.");
        }
    }
}