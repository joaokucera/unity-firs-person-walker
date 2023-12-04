using Assets.Scripts.GAME.Addressable;
using Assets.Scripts.GAME.Cannon;
using Assets.Scripts.GAME.Entity;
using Assets.Scripts.GAME.Player;
using Assets.Scripts.GAME.Pool;
using Assets.Scripts.GAME.Projectile;
using Assets.Scripts.GAME.Trigger;
using Assets.Scripts.GAME.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.GAME
{
    [RequireComponent(typeof(UIView))]
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        GameSettings gameSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            // Addressable
            builder.Register<AddressableModel>(Lifetime.Scoped);
            builder.Register<IAddressableService, AddressableService>(Lifetime.Scoped);

            // Pool
            builder.Register<PoolModel>(Lifetime.Scoped);
            builder.Register<PoolService>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<IPoolFactory, PoolFactory>(Lifetime.Scoped);

            // Player
            builder.RegisterInstance(gameSettings);
            builder.Register<IPlayerService, PlayerService>(Lifetime.Scoped);

            // UI
            builder.RegisterComponent(GetComponent<UIView>());
            builder.Register<UIPresenter>(Lifetime.Scoped)
                .AsImplementedInterfaces();

            // Entity + Trigger + Cannons
            var entityViews = FindObjectsOfType(typeof(EntityView));
            var triggerViews = FindObjectsOfType(typeof(TriggerView));
            var cannonsViews = FindObjectsOfType(typeof(CannonView));
            builder.Register<GameInitializer>(Lifetime.Scoped)
                .WithParameter(nameof(entityViews), entityViews)
                .WithParameter(nameof(triggerViews), triggerViews)
                .WithParameter(nameof(cannonsViews), cannonsViews)
                .AsImplementedInterfaces();

            // Projectile
            builder.Register<IProjectileFactory, ProjectileFactory>(Lifetime.Scoped);
        }
    }
}
