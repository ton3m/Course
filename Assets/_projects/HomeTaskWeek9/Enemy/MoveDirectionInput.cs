using UnityEngine;

public class MoveDirectionInput : IMoveDirectionInput, IDirectionProvider
{
    private IDirectionProvider _provider;

    public Vector3 Direction => _provider?.Direction ?? Vector3.zero;

    public IProcess ReadFrom(IDirectionProvider provider) =>
        new ActionProcess(
            () => _provider = provider,
            () => _provider = null);
}
