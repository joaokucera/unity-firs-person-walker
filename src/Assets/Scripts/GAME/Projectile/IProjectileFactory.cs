using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.GAME.Projectile
{
    public interface IProjectileFactory
    {
        Task<ProjectileView> CreateProjectileView(AssetReference assetReference, Transform referenceTransform);
    }
}
