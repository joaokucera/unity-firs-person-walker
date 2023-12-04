using System;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace Assets.Scripts.GAME.Addressable
{
    public class AddressableService : IAddressableService
    {
        readonly AddressableModel _addressableModel;

        public AddressableService(AddressableModel addressableModel)
        {
            _addressableModel = addressableModel;
        }

        public async Task<T> LoadAssetAsync<T>(AssetReference assetReference) where T : Object
        {
            ValidateRuntimeKeyIsValid(assetReference);

            object assetKey = assetReference.RuntimeKey;

            if (!_addressableModel.LoadedAssetsByAssetKey.TryGetValue(assetKey, out var obj))
            {
                obj = await LoadAssetAsyncInternal<T>(assetKey);
            }

            return obj as T;
        }

        async Task<Object> LoadAssetAsyncInternal<T>(object assetKey) where T : Object
        {
            var asyncOperationHandle = Addressables.LoadAssetAsync<T>(assetKey);
            var loadedAsset = await asyncOperationHandle.Task;

            if (asyncOperationHandle.Status == AsyncOperationStatus.Failed)
            {
                throw new Exception($"Failed to load asset {assetKey}");
            }

            _addressableModel.LoadedAssetsByAssetKey[assetKey] = loadedAsset;
            return loadedAsset;
        }

        static void ValidateRuntimeKeyIsValid(IKeyEvaluator assetReference)
        {
            if (!assetReference.RuntimeKeyIsValid())
            {
                throw new NullReferenceException("AssetReference has no runtime key defined");
            }
        }
    }
}
