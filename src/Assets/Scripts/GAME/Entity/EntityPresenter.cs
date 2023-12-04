using System;
using System.Collections;
using Assets.Scripts.GAME.Effect;
using Assets.Scripts.GAME.Trigger;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.GAME.Entity
{
    public class EntityPresenter
    {
        readonly IEntityView _entityView;
        protected readonly EntitySettings _entitySettings;
        protected Action<int> _onCurrentHealthChanged;
        protected Action _onDamageApplied;

        [Inject]
        protected readonly GameSettings _gameSettings;

        EntityPoisonEffect _currentPoisonEffect;
        Coroutine _poisonCoroutine;
        int _currentHealth;

        int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                _currentHealth = Math.Clamp(CurrentHealth, 0, _entitySettings.MaxHealth);

                _onCurrentHealthChanged?.Invoke(_currentHealth);
            }
        }

        public EntityPresenter(IEntityView entityView)
        {
            _entityView = entityView;
            _entitySettings = entityView.EntitySettings;
            _entityView.OnTriggerEnterCallback += OnTriggerEnter;

            CurrentHealth = _entitySettings.MaxHealth;
        }

        void OnTriggerEnter(Collider other)
        {
            var triggerView = other.GetComponent<ITriggerView>();

            if (triggerView == null)
            {
                return;
            }

            foreach (var effectSettings in triggerView.EffectSettingsList)
            {
                switch (effectSettings.EffectType)
                {
                    case EffectType.Heal:
                        Heal(triggerView.TriggerName, effectSettings);
                        break;
                    case EffectType.Poison:
                        Poison(effectSettings);
                        break;
                    case EffectType.Damage:
                        Damage(effectSettings.DamageAmount);
                        break;
                }
            }
        }

        void Heal(string triggerName, IEffectSettings effectSettings)
        {
            if (CurrentHealth >= _entitySettings.MaxHealth)
            {
                return;
            }

            if (effectSettings.HealAmount > 0)
            {
                CurrentHealth += effectSettings.HealAmount;

                _gameSettings.EffectHealLogSettings.LogFormat(triggerName);

                if (effectSettings.CanDepleteAfterHealing)
                {
                    effectSettings.HealAmount = 0;
                }
            }
            else
            {
                _gameSettings.EffectHealDepletedLogSettings.LogFormat(triggerName);
            }
        }

        void Poison(IEffectSettings effectSettings)
        {
            if (_entitySettings.IsImmortal || _entitySettings.IsImmuneToPoison)
            {
                return;
            }

            if (_currentPoisonEffect == null)
            {
                _currentPoisonEffect = new EntityPoisonEffect
                {
                    DamageAmount = effectSettings.DamageAmount,
                    PoisonDurationInSeconds = effectSettings.PoisonDurationInSeconds,
                    PoisonPeriodInSeconds = effectSettings.PoisonPeriodInSeconds
                };
            }
            else
            {
                if (effectSettings.DamageAmount > _currentPoisonEffect.DamageAmount)
                {
                    _currentPoisonEffect.DamageAmount = effectSettings.DamageAmount;
                }

                if (effectSettings.PoisonPeriodInSeconds < _currentPoisonEffect.PoisonPeriodInSeconds)
                {
                    _currentPoisonEffect.PoisonPeriodInSeconds = effectSettings.PoisonPeriodInSeconds;
                }

                _currentPoisonEffect.PoisonDurationInSeconds += effectSettings.PoisonDurationInSeconds;
            }

            if (_poisonCoroutine != null)
            {
                _entityView.CancelCoroutine(_poisonCoroutine);
            }

            _poisonCoroutine = _entityView.StartCoroutine(PoisonCoroutine(_currentPoisonEffect));
        }

        IEnumerable PoisonCoroutine(EntityPoisonEffect entityPoisonEffect)
        {
            Damage(entityPoisonEffect.DamageAmount);

            while (entityPoisonEffect.PoisonDurationInSeconds > 0f)
            {
                yield return new WaitForSeconds(entityPoisonEffect.PoisonPeriodInSeconds);
                entityPoisonEffect.PoisonDurationInSeconds -= entityPoisonEffect.PoisonPeriodInSeconds;

                Damage(entityPoisonEffect.DamageAmount);
            }

            _currentPoisonEffect = null;
        }

        void Damage(int damageAmount)
        {
            if (_entitySettings.IsImmortal || _entitySettings.IsImmuneToDamage || _currentHealth <= 0)
            {
                return;
            }

            CurrentHealth -= damageAmount;

            _gameSettings.EntityDamageLogSettings.LogFormat(_entitySettings.Name, CurrentHealth);
            _onDamageApplied?.Invoke();

            if (_currentHealth > 0)
            {
                return;
            }

            Kill();
        }

        void Kill()
        {
            _gameSettings.EntityKilledLogSettings.LogFormat(_entitySettings.Name);
        }
    }
}
