using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GAME.Addressable
{
    public class AddressableModel
    {
        public readonly Dictionary<object, Object> LoadedAssetsByAssetKey = new();
    }
}
