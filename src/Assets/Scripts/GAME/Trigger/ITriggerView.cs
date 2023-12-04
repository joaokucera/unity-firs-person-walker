using System.Collections.Generic;
using Assets.Scripts.GAME.Effect;

namespace Assets.Scripts.GAME.Trigger
{
    public interface ITriggerView
    {
        string TriggerName { get; }
        List<EffectSettings> EffectSettingsList { get; }
    }
}
