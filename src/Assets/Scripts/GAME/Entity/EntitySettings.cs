using System;
using UnityEngine;

namespace Assets.Scripts.GAME.Entity
{
    [Serializable]
    public class EntitySettings : IEntitySettings
    {
        [SerializeField]
        string name;

        [SerializeField]
        bool isPlayer;

        [SerializeField]
        bool isImmortal;

        [SerializeField]
        bool isImmuneToDamage;

        [SerializeField]
        bool isImmuneToPoison;

        [SerializeField]
        int maxHealth;

        public string Name => name;
        public bool IsPlayer => isPlayer;
        public bool IsImmortal => isImmortal;
        public bool IsImmuneToDamage => isImmuneToDamage;
        public bool IsImmuneToPoison => isImmuneToPoison;
        public int MaxHealth => maxHealth;
    }
}
