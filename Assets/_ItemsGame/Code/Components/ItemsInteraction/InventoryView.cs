using UnityEngine;

namespace ItemsGame.ItemsHandlers
{
    public class InventoryView : IInventoryView
    {
        private GameObject _itemView;
        private readonly Transform _viewPoint;

        public InventoryView(Transform viewPoint)
        {
            _viewPoint = viewPoint;
        }

        public bool CanAdd(GameObject itemView) => CanAddCaught(itemView, out _);

        public void Add(GameObject itemView)
        {
            if (CanAddCaught(itemView, out string message) == false)
            {
                Debug.LogError(message);
                return;
            }

            _itemView = Object.Instantiate(itemView, _viewPoint, false);
            _itemView.transform.localPosition = Vector3.zero;
        } 

        public void Clear()
        {
            if (_itemView != null) 
                Object.Destroy(_itemView);
            
            _itemView = null;
        }

        private bool CanAddCaught(GameObject itemView, out string message)
        {
            if (_itemView is not null)
            {
                message = "Inventory view is full.";
                return false;
            }

            if (itemView == null)
            {
                message = "Cant add NULL item.";
                return false;
            }

            message = "Can be added.";
            return true;
        }
    }
}