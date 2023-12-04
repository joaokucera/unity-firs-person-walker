using Assets.Scripts.GAME.Pool;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.GAME.Projectile
{
    public class ProjectilePresenter
    {
        readonly IProjectileView _projectileView;

        [Inject]
        readonly IPoolService _poolService;

        [Inject]
        readonly GameSettings _gameSettings;

        public ProjectilePresenter(IProjectileView projectileView, Transform referenceTransform)
        {
            _projectileView = projectileView;
            _projectileView.OnTriggerEnterCallback += OnTriggerEnter;

            var projectileTransform = _projectileView.Transform;
            projectileTransform.position = referenceTransform.position;
            projectileTransform.rotation = referenceTransform.rotation;
        }

        public void StartMoving()
        {
            _projectileView.OnUpdateCallback += OnUpdated;
        }

        void OnUpdated(float deltaTime)
        {
            _projectileView.Transform.Translate(Vector3.forward * deltaTime * _gameSettings.ProjectileSpeed);
        }

        void OnTriggerEnter(Collider other)
        {
            _poolService.ReturnPooledObject(_projectileView.Transform.gameObject);
        }
    }
}
