using System.Threading.Tasks;
using Assets.Scripts.GAME.Pool;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;

namespace Assets.Scripts.GAME.Projectile
{
    public class ProjectileFactory : IProjectileFactory
    {
        readonly IObjectResolver _container;
        readonly IPoolService _poolService;

        public ProjectileFactory(IObjectResolver container, IPoolService poolService)
        {
            _container = container;
            _poolService = poolService;
        }

        public async Task<ProjectileView> CreateProjectileView(AssetReference assetReference,
            Transform referenceTransform)
        {
            var projectileInstance = await _poolService.GetPooledObjectAsync(assetReference);
            var projectileView = projectileInstance.AddComponent<ProjectileView>();

            var projectilePresenter = new ProjectilePresenter(projectileView, referenceTransform);
            _container.Inject(projectilePresenter);
            projectilePresenter.StartMoving();

            return projectileView;
        }
    }
}
