using System;
using System.Collections.Generic;

public class Updater : IUpdater
{
    List<IUpdatableBehaviour> updatables = new();

    public void UpdateAll()
    {
        List<IUpdatableBehaviour> updatablesCopy = new(updatables);

        updatablesCopy.ForEach(updatable => updatable?.Update());
    }

    public IProcess GetNewProcess(IUpdatableBehaviour updatable)
    {
        if (updatable is null)
            throw new NullReferenceException();

        return new ActionProcess(
            () => updatables.Add(updatable),
            () => updatables.Remove(updatable));
    }
}
