using Assets.Scripts.GAME.Cannon;
using Assets.Scripts.GAME.Entity;
using Assets.Scripts.GAME.Player;
using Assets.Scripts.GAME.Trigger;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.GAME
{
    public class GameInitializer : IInitializable
    {
        readonly IObjectResolver _container;
        readonly EntityView[] _entityViews;
        readonly TriggerView[] _triggerViews;
        readonly CannonView[] _cannonViews;

        public GameInitializer(IObjectResolver container, EntityView[] entityViews, TriggerView[] triggerViews,
            CannonView[] cannonsViews)
        {
            _container = container;
            _entityViews = entityViews;
            _triggerViews = triggerViews;
            _cannonViews = cannonsViews;
        }

        public void Initialize()
        {
            foreach (var entityView in _entityViews)
            {
                if (entityView.EntitySettings.IsPlayer)
                {
                    var playerPresenter = new PlayerPresenter(entityView);
                    _container.Inject(playerPresenter);
                    playerPresenter.SetCurrentHealth(entityView.EntitySettings.MaxHealth);
                }
                else
                {
                    var entityPresenter = new EntityPresenter(entityView);
                    _container.Inject(entityPresenter);
                }
            }

            foreach (var triggerView in _triggerViews)
            {
                var triggerPresenter = new TriggerPresenter(triggerView);
                _container.Inject(triggerPresenter);
            }

            foreach (var cannonView in _cannonViews)
            {
                var cannonPresenter = new CannonPresenter(cannonView);
                _container.Inject(cannonPresenter);
            }
        }
    }
}
