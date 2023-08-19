using UnityEngine;
using Zenject;

public class PlayerFactory : PlaceholderFactory<Player>
{
    public Player Create(Transform spawnPoint)
    {
        Player player = base.Create();
        player.transform.position = spawnPoint.position + new Vector3(0, 2, 0);
        return player;
    }
}
