using System;
using ItemsGame.Code.New.ItemsHandlers;
using UnityEngine;

namespace ItemsGame.Code.New
{
    [RequireComponent(typeof(Collider))]
    public class ItemsCollector : MonoBehaviour
    {
        private Inventory _inventory;

        public void Init(Inventory inventory)
        {
            _inventory = inventory;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IItem item))
            {
                if (_inventory.CanAddItem(item))
                {
                    _inventory.AddItem(item);
                }
                else
                {
                    Debug.Log("Item cant be added");
                }
            }
        }
    }
}