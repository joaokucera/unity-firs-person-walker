using System;
using Assets.Scripts.GAME.Trigger;
using UnityEngine;

namespace Assets.Scripts.GAME.Projectile
{
    public class ProjectileView : TriggerView, IProjectileView
    {
        public Transform Transform => transform;
        public Action<float> OnUpdateCallback { get; set; }
        public Action<Collider> OnTriggerEnterCallback { get; set; }

        void Update()
        {
            OnUpdateCallback?.Invoke(Time.deltaTime);
        }

        void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterCallback?.Invoke(other);
        }
    }
}
