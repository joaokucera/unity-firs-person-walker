using UnityEngine;

namespace Assets.Scripts.GAME
{
    public static class GameLogExtensions
    {
        public static void LogFormat(this GameLogSettings gameLogSettings, params object[] args)
        {
            if (gameLogSettings.IsEnabled)
            {
                Debug.LogFormat(gameLogSettings.LogMessage, args);
            }
        }
    }
}
