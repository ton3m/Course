using UnityEngine;

namespace ItemsGame
{
    [RequireComponent(typeof(Collider))]
    public class ItemsCollector : MonoBehaviour
    {
        private IInventory _inventory;

        public void Init(IInventory inventory)
        {
            _inventory = inventory;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IItemHolder holder))
            {
                IItem item = holder.GetItem();

                Result canAdd = _inventory.CanAddItem(item);

                if (canAdd.IsSuccess)
                {
                    _inventory.AddItem(item);
                    Destroy(other.gameObject);
                }
                else
                {
                    Debug.Log(canAdd.Message);
                }
            }
        }
    }
}