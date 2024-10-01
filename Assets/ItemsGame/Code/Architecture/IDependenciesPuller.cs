using System.Collections.Generic;

namespace ItemsGame.Code.New
{
    public interface IDependenciesPuller
    {
        List<string> Dependencies { get; }
        bool CanInitFrom(DependenciesContainer container);
        void InitFrom(DependenciesContainer container);
    }
}