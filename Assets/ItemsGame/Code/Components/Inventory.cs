using System;
using UnityEngine;

namespace ItemsGame.Code.New.ItemsHandlers
{
    public class Inventory
    {
        private IItem _item;
        private Func<IItem, bool> _canUseItem;

        public bool HasItem => _item is not null;

        public Inventory()
        {
            _canUseItem = _ => false;
        }


        public bool CanAddItem(IItem item) =>
            HasItem == false && _canUseItem(item);

        public void AddItem(IItem item)
        {
            if (CanAddItem(item) == false)
            {
                Debug.LogError("Can't add item.");
                return;
            }

            _item = item;

            Debug.Log("Item added");
        }

        public IItem GetItem() => _item;

        private void Clear() => _item = null;
    }
}