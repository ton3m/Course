using UnityEngine;

namespace ItemsGame
{
    public class DependenciesHolder
    {
        public DependenciesHolder(GameObject container)
        {
            Container = container;
        }

        public GameObject Container { get; }
    }
}