using UnityEngine;

namespace Assets.Scripts.GAME
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField, Range(1f, 100f)]
        float projectileSpeed;

        [SerializeField]
        GameLogSettings playerDamageLogSettings =
            new(true, "<color=cyan>I am a {0} and I got damage!</color>");

        [SerializeField]
        GameLogSettings entityDamageLogSettings =
            new(true, "<color=magenta>I am a {0} and my current health is {1}!</color>");

        [SerializeField]
        GameLogSettings entityKilledLogSettings =
            new(true, "<color=red>I am a {0} and I was destroyed!</color>");

        [SerializeField]
        GameLogSettings effectHealLogSettings =
            new(true, "<color=yellow>I am a healing {0} and I will heal you!</color>");

        [SerializeField]
        GameLogSettings effectHealDepletedLogSettings =
            new(true, "<color=white>I am a healing {0} but now I am depleted!</color>");

        public float ProjectileSpeed => projectileSpeed;
        public GameLogSettings PlayerDamageLogSettings => playerDamageLogSettings;
        public GameLogSettings EntityDamageLogSettings => entityDamageLogSettings;
        public GameLogSettings EntityKilledLogSettings => entityKilledLogSettings;
        public GameLogSettings EffectHealLogSettings => effectHealLogSettings;
        public GameLogSettings EffectHealDepletedLogSettings => effectHealDepletedLogSettings;
    }
}
