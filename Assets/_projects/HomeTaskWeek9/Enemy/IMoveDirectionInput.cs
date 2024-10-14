public interface IMoveDirectionInput : IDirectionProvider
{
    IProcess ReadFrom(IDirectionProvider provider);
}
