using UnityEngine;

namespace ItemsGame.Code.New
{
    public class DependenciesContainer
    {
        public DependenciesContainer(GameObject holder)
        {
            Holder = holder;
        }

        public GameObject Holder { get; }
    }
}