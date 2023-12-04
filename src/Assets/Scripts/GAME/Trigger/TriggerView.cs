using System.Collections.Generic;
using Assets.Scripts.GAME.Effect;
using UnityEngine;

namespace Assets.Scripts.GAME.Trigger
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class TriggerView : MonoBehaviour, ITriggerView
    {
        [SerializeField]
        string triggerName;

        [SerializeField]
        List<EffectSettings> effectSettingsList = new();

        public string TriggerName => triggerName;
        public List<EffectSettings> EffectSettingsList => effectSettingsList;

        void OnValidate()
        {
            GetComponent<Collider>().isTrigger = true;
            GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
