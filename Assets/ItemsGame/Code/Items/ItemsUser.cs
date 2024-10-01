using UnityEngine;

namespace ItemsGame.Code.New
{
    public class ItemsUser
    {
        private readonly DependenciesContainer _container;
        private readonly string _userName;

        public ItemsUser(DependenciesContainer container)
        {
            _container = container;
            _userName = _container.Holder.name;
        }

        public bool CanUse(IItem item)
        {
            return false;
            
            string itemType = item.GetType().ToString();

            if (item.CanInitFrom(_container))
            {
                item.InitFrom(_container);
                Debug.Log($"{itemType} successfully initialized by {_userName}!");
            }
            else
            {
                Debug.LogError($"Failed to initialize {itemType} by {_userName}!");
                Debug.LogError($"Required dependencies: {string.Join(", ", item.Dependencies)}");
            }

            if (item.CanUse())
            {
                item.Use();
                Debug.Log($"{itemType} successfully used by {_userName}!");
            }
            else
            {
                Debug.Log($"Can't use {itemType} by {_userName}.");
            }
        }

        public void Use(IItem item)
        {
            
        }
    }
}