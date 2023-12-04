using System;

namespace Assets.Scripts.GAME.Player
{
    public interface IPlayerService
    {
        Action<int> OnCurrentHealthChanged { get; set; }
        int CurrentHealth { get; }
        void UpdateCurrentHealth(int currentHealth);
    }
}
