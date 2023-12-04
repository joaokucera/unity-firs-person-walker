using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GAME.Entity
{
    public interface IEntityView
    {
        EntitySettings EntitySettings { get; }
        Action<Collider> OnTriggerEnterCallback { get; set; }
        Coroutine StartCoroutine(IEnumerable coroutine);
        void CancelCoroutine(Coroutine coroutine);
    }
}
