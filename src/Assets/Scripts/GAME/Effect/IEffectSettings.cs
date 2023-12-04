namespace Assets.Scripts.GAME.Effect
{
    public interface IEffectSettings
    {
        EffectType EffectType { get; }
        bool CanDepleteAfterHealing { get; }
        int HealAmount { get; set; }
        int DamageAmount { get; }
        float PoisonDurationInSeconds { get; }
        float PoisonPeriodInSeconds { get; }
    }
}
