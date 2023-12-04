using System;
using UnityEngine;

namespace Assets.Scripts.GAME.Projectile
{
    public interface IProjectileView
    {
        Transform Transform { get; }
        Action<float> OnUpdateCallback { get; set; }
        Action<Collider> OnTriggerEnterCallback { get; set; }
    }
}
