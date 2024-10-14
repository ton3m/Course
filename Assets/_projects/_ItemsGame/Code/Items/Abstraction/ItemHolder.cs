using UnityEngine;

namespace ItemsGame
{
    public abstract class ItemHolder : MonoBehaviour, IItemHolder
    {
        protected abstract IItem GetItemBase();
        
        public IItem GetItem()
        {
            IItem item = GetItemBase();
            item.SetView(gameObject);

            return item;
        }
    }
}