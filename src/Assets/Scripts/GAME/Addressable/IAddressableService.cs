using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.GAME.Addressable
{
    public interface IAddressableService
    {
        Task<T> LoadAssetAsync<T>(AssetReference assetReference) where T : Object;
    }
}
