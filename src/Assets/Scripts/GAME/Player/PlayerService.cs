using System;

namespace Assets.Scripts.GAME.Player
{
    public class PlayerService : IPlayerService
    {
        public Action<int> OnCurrentHealthChanged { get; set; }
        public int CurrentHealth { get; private set; }

        public void UpdateCurrentHealth(int currentHealth)
        {
            CurrentHealth = currentHealth;
            OnCurrentHealthChanged?.Invoke(CurrentHealth);
        }
    }
}
