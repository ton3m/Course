using UnityEngine;

namespace ItemsGame
{
    public interface IItem
    {
        GameObject View { get; }
        string Name { get; }
        
        void SetView(GameObject view);
        void Use(DependenciesHolder holder);
        bool CanUse(DependenciesHolder holder); 
    }
}