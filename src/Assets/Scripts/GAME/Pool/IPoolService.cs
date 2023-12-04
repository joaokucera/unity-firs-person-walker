using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.GAME.Pool
{
    public interface IPoolService
    {
        Task<GameObject> GetPooledObjectAsync(AssetReference assetReference, Transform parent = null);

        void ReturnPooledObject(GameObject objectToReturn);

        void ReturnPooledObject(string assetName, GameObject objectToReturn);

        void ReturnAllPooledChildren(Transform parent);
    }
}
