using UnityEngine;

namespace Assets.Scripts.GAME.Pool
{
    public interface IPoolFactory
    {
        PoolView CreatePoolView(GameObject prefab);
    }
}
