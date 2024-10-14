using UnityEngine;

namespace ItemsGame.ItemsHandlers
{
    public interface IInventoryView
    {
        bool CanAdd(GameObject itemView);
        void Add(GameObject itemView);
        void Clear();
    }
}