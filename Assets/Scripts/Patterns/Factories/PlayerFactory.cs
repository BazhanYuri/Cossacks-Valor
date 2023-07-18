using Zenject;

public class PlayerFactory : PlaceholderFactory<Player>, IInitializable
{
    public void Initialize()
    {
        Create();
    }
}
