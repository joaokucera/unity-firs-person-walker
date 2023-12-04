using System.Collections;
using Assets.Scripts.GAME.Projectile;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.GAME.Cannon
{
    public class CannonPresenter
    {
        readonly ICannonView _cannonView;
        readonly WaitForSeconds _shootingPeriodWaitForSeconds;

        [Inject]
        readonly GameSettings _gameSettings;

        [Inject]
        IProjectileFactory _projectileFactory;

        public CannonPresenter(ICannonView cannonView)
        {
            _cannonView = cannonView;
            _shootingPeriodWaitForSeconds = new WaitForSeconds(_cannonView.CannonSettings.ShootingPeriodInSeconds);

            _cannonView.StartCoroutine(ShootProjectileCoroutine());
        }

        IEnumerable ShootProjectileCoroutine()
        {
            while (true)
            {
                yield return _shootingPeriodWaitForSeconds;

                _projectileFactory.CreateProjectileView(
                    _cannonView.CannonSettings.ProjectileViewAssetReference, _cannonView.ShootingPoint);
            }
        }
    }
}
