using System;
using UnityEngine;

namespace Assets.Scripts.GAME
{
    [Serializable]
    public class GameLogSettings
    {
        [SerializeField]
        bool isEnabled;

        [SerializeField]
        string logMessage;

        public bool IsEnabled => isEnabled;
        public string LogMessage => logMessage;

        public GameLogSettings(bool isEnabled, string logMessage)
        {
            this.isEnabled = isEnabled;
            this.logMessage = logMessage;
        }
    }
}
