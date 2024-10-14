using UnityEngine;

namespace ItemsGame
{
    public class ItemUser : IItemUser
    {
        private readonly DependenciesHolder _holder;

        public ItemUser(DependenciesHolder holder, string name)
        {
            _holder = holder;
            Name = name;
        }

        public string Name { get; }

        public void Use(IItem item)
        {
            if (CanUse(item))
                item.Use(_holder);
            else
                Debug.LogError($"Can't use {item.Name}!");
        }

        public bool CanUse(IItem item) => item.CanUse(_holder);
    }
}