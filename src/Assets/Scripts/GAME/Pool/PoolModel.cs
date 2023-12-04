using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GAME.Pool
{
    public class PoolModel
    {
        public readonly Dictionary<string, Stack<GameObject>> PoolsByAssetName = new();
    }
}
