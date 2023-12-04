using System;
using UnityEngine;

namespace Assets.Scripts.GAME.Effect
{
    [Serializable]
    public class EffectSettings : IEffectSettings
    {
        [SerializeField]
        EffectType effectType;

        [SerializeField]
        bool canDepleteAfterHealing;

        [SerializeField]
        int healAmount;

        [SerializeField]
        int damageAmount;

        [SerializeField]
        float poisonDurationInSeconds;

        [SerializeField]
        float poisonPeriodInSeconds;

        public EffectType EffectType => effectType;
        public bool CanDepleteAfterHealing => canDepleteAfterHealing;

        public int HealAmount
        {
            get => healAmount;
            set => healAmount = value;
        }

        public int DamageAmount => damageAmount;
        public float PoisonDurationInSeconds => poisonDurationInSeconds;
        public float PoisonPeriodInSeconds => poisonPeriodInSeconds;
    }
}
