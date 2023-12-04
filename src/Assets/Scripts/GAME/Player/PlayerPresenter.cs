using Assets.Scripts.GAME.Entity;
using VContainer;

namespace Assets.Scripts.GAME.Player
{
    public class PlayerPresenter : EntityPresenter
    {
        [Inject]
        readonly IPlayerService _playerService;

        public PlayerPresenter(IEntityView entityView) : base(entityView)
        {
            _onCurrentHealthChanged = OnCurrentHealthChanged;
            _onDamageApplied = OnDamageApplied;
        }

        public void SetCurrentHealth(int currentHealth)
        {
            _playerService.UpdateCurrentHealth(currentHealth);
        }

        void OnCurrentHealthChanged(int currentHealth)
        {
            SetCurrentHealth(currentHealth);
        }

        void OnDamageApplied()
        {
            _gameSettings.PlayerDamageLogSettings.LogFormat(_entitySettings.Name);
        }
    }
}
