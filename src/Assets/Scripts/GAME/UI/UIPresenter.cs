using Assets.Scripts.GAME.Player;
using VContainer.Unity;

namespace Assets.Scripts.GAME.UI
{
    public class UIPresenter : IInitializable
    {
        readonly UIView _uiView;
        readonly IPlayerService _playerService;

        public UIPresenter(UIView uiView, IPlayerService playerService)
        {
            _uiView = uiView;
            _playerService = playerService;
        }

        public void Initialize()
        {
            _playerService.OnCurrentHealthChanged += OnCurrentHealthChanged;
        }

        void OnCurrentHealthChanged(int currentHealth)
        {
            _uiView.PlayerCurrentHealthText.text = currentHealth.ToString();
        }
    }
}
