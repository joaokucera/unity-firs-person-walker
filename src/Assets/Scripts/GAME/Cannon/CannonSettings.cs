using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.GAME.Cannon
{
    [Serializable]
    public class CannonSettings : ICannonSettings
    {
        [SerializeField]
        float shootingPeriodInSeconds;

        [SerializeField]
        AssetReference projectileViewAssetReference;

        public float ShootingPeriodInSeconds => shootingPeriodInSeconds;
        public AssetReference ProjectileViewAssetReference => projectileViewAssetReference;
    }
}
